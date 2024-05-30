using Infraestructure.Interfaces;
using Infraestructure.Models;

namespace Infraestructure.Content.Interfaces;

public interface ITemplateData<TEntity> where TEntity : class
{
    Task<IEnumerable<Template>> GetByGenreAsync(string genre);
    Task<Template> GetByDescriptionAsync(string description);
    Task<Template> GetByCoverImageAsync(string imgUrl);
}