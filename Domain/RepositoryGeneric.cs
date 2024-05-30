using Domain.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Models;

namespace Domain;

public class RepositoryGeneric<TEntity>(IRepository<TEntity> repository) : IRepositoryGeneric<TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository = repository;
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        if (entity is Template template)
        {
            if (template.Type == "Illustration" && !string.IsNullOrWhiteSpace(template.Genre))
            {
                throw new ArgumentException("When the Type is 'Illustration', the Genre needs to be an empty string.");
            }

            template.Genre = template.Genre ?? string.Empty;
        }
        
        await _repository.Add(entity);
    }

    public async Task Update(TEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}