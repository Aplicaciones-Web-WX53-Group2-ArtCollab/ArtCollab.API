namespace Domain.Interfaces;

public interface IRepositoryGeneric<TEntity> where TEntity: class
{
    Task<int> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity, int id);
    Task DeleteAsync(int id);
}