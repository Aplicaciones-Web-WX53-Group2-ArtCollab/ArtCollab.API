namespace Application.Monetization.Shared.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}