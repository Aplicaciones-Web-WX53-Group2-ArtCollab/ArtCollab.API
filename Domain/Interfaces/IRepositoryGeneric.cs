namespace Domain.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Delete(int id);
    }
}