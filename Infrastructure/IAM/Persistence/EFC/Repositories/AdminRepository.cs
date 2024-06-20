using Domain.IAM.Model.Aggregates;
using Domain.IAM.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.IAM.Persistence.EFC.Repositories;

public class AdminRepository(AppDbContext context) : BaseRepository<Admin>(context), IAdminRepository
{
    public async Task<Admin?> FindByUsernameAsync(string username)
    {
        return await context.Set<Admin>().FirstOrDefaultAsync(a => a.Username == username);
    }

    public bool ExistsByUsername(string username)
    {
        return context.Set<Admin>().Any(a => a.Username == username);
    }
}