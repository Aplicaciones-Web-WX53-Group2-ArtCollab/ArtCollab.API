namespace Domain.Content.Interfaces;

public interface IContentDomain<TEntity> where TEntity : class
{
    Task Add(TEntity entity);
    Task Delete(int id);
}