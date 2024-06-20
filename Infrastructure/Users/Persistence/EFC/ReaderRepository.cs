using Domain.User.Model.Aggregates;
using Domain.User.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.Persistence.EFC;

public class ReaderRepository(AppDbContext context) : BaseRepository<Reader>(context), IReaderRepository
{
    public bool ReaderExistsByEmailAndPassword(string email, string password)
    {
        return context.Set<Reader>().Any(reader => reader.Email == email && reader.Password == password);
    }

    public bool ReaderExistsByUsername(string username)
    {
        return context.Set<Reader>().Any(reader => reader.Username == username);
    }
    
    public async Task<IEnumerable<Reader?>> GetAllReadersByType(string type)
    {
        return await context.Set<Reader>().Where(reader => reader.Type == type).ToListAsync();
    }
}