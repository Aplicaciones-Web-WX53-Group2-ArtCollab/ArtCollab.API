using Domain.Interfaces;
using Infraestructure.Interfaces;

namespace Domain;

public class SubscriptionDomain<TEntity>(ISubscriptionData<TEntity> subscriptionData) : ISubscriptionDomain<TEntity> where TEntity : class
{
    private readonly ISubscriptionData<TEntity> _subscriptionData = subscriptionData;
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _subscriptionData.GetAllAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _subscriptionData.GetByIdAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        await _subscriptionData.Add(entity);
    }

    public async Task Update(TEntity entity)
    {
        await _subscriptionData.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _subscriptionData.Delete(id);
    }
}