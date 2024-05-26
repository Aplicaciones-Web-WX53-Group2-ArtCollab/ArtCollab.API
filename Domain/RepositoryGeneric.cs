using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class RepositoryGeneric<TEntity>: IRepositoryGeneric<TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;
    private readonly IReaderData _readerData;

    public RepositoryGeneric(IRepository<TEntity> repository,IReaderData readerData)
    {
        _repository = repository;
        _readerData = readerData;
    }

    public async Task<int> AddAsync(TEntity entity)
    {
        if (entity is Reader reader)
        {
            var existingReaderByUserName = await _readerData.GetByUserNameAsync(reader.UserName);
            if (existingReaderByUserName != null)
            {
                throw new Exception("A reader with the same username already exists.");
            }
            var existingReaderByEmail = await _readerData.GetByEmailAsync(reader.Email);
            if (existingReaderByEmail != null)
            {
                throw new Exception("A reader with the same email already exists.");
            }
        }
        return await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity, int id)
    {
        var existingEntity = await _repository.GetByIdAsync(id);
        await _repository.UpdateAsync(entity, id);
    }

    public async Task DeleteAsync(int id)
    {
        var existingEntity = await _repository.GetByIdAsync(id);
        if (existingEntity == null)
        {
            throw new Exception("Entity not found.");
        }
        await _repository.DeleteAsync(id);

    }
}