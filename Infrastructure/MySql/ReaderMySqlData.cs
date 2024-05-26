using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MySql;

public class ReaderMySqlData : IReaderData
{
    private readonly IRepository<Reader> _repository;
    private readonly ArtCollabDbContext _context;

    public ReaderMySqlData(IRepository<Reader> repository, ArtCollabDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IEnumerable<Reader>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Reader> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<int> AddAsync(Reader entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(Reader entity, int id)
    {
        await _repository.UpdateAsync(entity, id);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Reader> GetByUserNameAsync(string userName)
    {
        return await _context.Readers.FirstOrDefaultAsync(i => i.UserName == userName);
    }

    public async Task<Reader> GetByEmailAsync(string email)
    {
        return await _context.Readers.FirstOrDefaultAsync(i => i.Email == email);
    }

    public async Task<Reader> GetByUserNameAndPasswordAsync(string userName, string password)
    {
        return await _context.Readers.FirstOrDefaultAsync(i => i.UserName == userName && i.Password == password);
    }
}