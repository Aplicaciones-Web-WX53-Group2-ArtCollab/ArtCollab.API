namespace Application.Monetization.Domain.Model.Aggregates;

public abstract class Observer<TEntity>
{
    public abstract void Update(TEntity entity);
    
}