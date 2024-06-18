using Infrastructure.Shared.Context;
using Infrastructure.Shared.Interfaces;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.MySql;

public class ReaderMySqlData : IReaderData
{
    private readonly IRepository<Reader> _repository;
    private readonly AppDbContext _context;

    public ReaderMySqlData(IRepository<Reader> repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IEnumerable<Reader>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Reader?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(Reader entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(Reader entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Reader?> GetByUserNameAsync(string userName)
    {
        return await _context.Readers.FirstOrDefaultAsync(i => i.UserName == userName);
    }

    public async Task<Reader> GetByEmailAsync(string email)
    {
        return await _context.Readers.FirstOrDefaultAsync(i => i.Email == email);
    }

    public async Task<int?> GetByEmailAndPasswordAsync(string Email, string password)
    {
        var reader = await _context.Readers.FirstOrDefaultAsync(i => i.Email == Email && i.Password == password);
        return reader?.Id;
    }
}