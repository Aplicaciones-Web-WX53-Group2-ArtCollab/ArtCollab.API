namespace Domain.Interfaces;

public interface ISubscriptionDomain<TEntity> where TEntity : class
{
    //Boolean Save(Subscription data);
    //Boolean Update(Subscription data);
    //Boolean Delete(int id);
    //List<Subscription> getAll();
    //List<Subscription> getById(int Id);

    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
}