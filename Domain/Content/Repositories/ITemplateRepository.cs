using Domain.Content.Models.Aggregate;

namespace Domain.Content.Repositories;

public interface ITemplateRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<Template?>> GetByGenreAsync(string genre);
    Task<Template?> GetByDescriptionAsync(string description);
    Task<Template> GetByCoverImageAsync(string imgUrl);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
}