namespace Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<int> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity, int id);
    Task DeleteAsync(int id);
}