using Application.Monetization.Domain.Model.Aggregates;
using Application.Monetization.Domain.Repository;
using Application.Monetization.Shared.Domain.Repositories;

namespace Application.Monetization.Data.Persistence.EFC.Repositories;

public class SubscriptionRepository(ISubscriptionRepository repository) : ISubscriptionRepository
{
    public async Task AddAsync(Subscription entity)
    {
        await repository.AddAsync(entity);
    }

    public async Task<Subscription?> FindByIdAsync(int id)
    {
        return await repository.FindByIdAsync(id);
    }

    public async Task Update(Subscription entity)
    {
        await repository.Update(entity);
    }

    public async Task Remove(Subscription entity)
    {
        await repository.Remove(entity);
    }

    public async Task<IEnumerable<Subscription>> ListAsync()
    {
        return await repository.ListAsync();
    }

    public async Task<IEnumerable<Subscription>> finbyIsActive(bool isActive)
    {
        return await repository.finbyIsActive(isActive);
    }

    public async Task<IEnumerable<Subscription>> finbyIsNotActive(bool isActive)
    {
        return await repository.finbyIsNotActive(isActive);
    }
}