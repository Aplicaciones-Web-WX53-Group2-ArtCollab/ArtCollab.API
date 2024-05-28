using Domain.Monetization.Repository;
using Shared.Domain.Interfaces;

namespace Infraestructure.Monetization.Persistence.EFC.Repository;

public class RepositoryGeneric<TEntity>(IBaseRepository<TEntity> repository): IRepositoryGeneric<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity)
    {
        await repository.AddAsync(entity);
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await repository.FindByIdAsync(id);
    }

    public async Task Update(TEntity entity)
    {
        await repository.Update(entity);
    }

    public async Task Remove(TEntity entity)
    {
        await repository.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await repository.ListAsync();
    }
}