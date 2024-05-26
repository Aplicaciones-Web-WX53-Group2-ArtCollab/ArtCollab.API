using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Domain.Repository;

namespace Application.Monetization.Data.Persistence.EFC.Repositories;

public class ReaderRepository (IReaderRepository repository) : IReaderRepository
{
    public async Task AddAsync(Reader entity)
    {
        await repository.AddAsync(entity);
    }

    public async Task<Reader?> FindByIdAsync(int id)
    {
        return await repository.FindByIdAsync(id);
    }

    public async Task Update(Reader entity)
    {
        await repository.Update(entity);
    }

    public async Task Remove(Reader entity)
    {
        await repository.Remove(entity);
    }

    public async Task<IEnumerable<Reader>> ListAsync()
    {
        return await repository.ListAsync();
    }

    public async Task<IEnumerable<Reader>> FindByUsername(string username)
    {
        return await repository.FindByUsername(username);
    }

    public async Task<IEnumerable<Reader>> FindByType(string type)
    {
        return await repository.FindByType(type);
    }

    public async Task<Reader> FindByEmail(string email)
    {
        return await repository.FindByEmail(email);
    }
}