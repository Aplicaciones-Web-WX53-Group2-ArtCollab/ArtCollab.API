namespace Domain.Interfaces;

public interface IRepositoryGeneric<TEntity> where TEntity: class
{
    Task<int> AddAsync(TEntity entity);
}