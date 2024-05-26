using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Domain.Repository;
using Application.Monetization.Shared.Domain.Repositories;

namespace Application.Monetization.Data.Persistence.EFC.Repositories;

public class CommisionRepository(ICommisionRepository repository) :ICommisionRepository
{
    public async Task AddAsync(Commision entity)
    {
        await repository.AddAsync(entity);
    }

    public async Task<Commision?> FindByIdAsync(int id)
    {
        return await repository.FindByIdAsync(id);
    }

    public async Task Update(Commision entity)
    {
        await repository.Update(entity);
    }

    public async Task Remove(Commision entity)
    {
        await repository.Remove(entity);
    }

    public async Task<IEnumerable<Commision>> ListAsync()
    {
        return await repository.ListAsync();
    }

    public async Task<Commision> GetCommisionByDate(DateTime date)
    {
        return await repository.GetCommisionByDate(date);
    }

    public async Task<Commision> GetCommisionByAmount(double amount)
    {
        return await repository.GetCommisionByAmount(amount);
    }

    public async Task<Commision> GetCommisionByContent(string content)
    {
        return await repository.GetCommisionByContent(content);
    }
}