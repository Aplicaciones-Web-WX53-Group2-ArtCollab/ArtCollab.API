using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.Model;

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

            var readerType = reader.Type.ToLower();
            if (readerType != "reader" && readerType != "artist")
            {
                throw new Exception("Invalid reader type: Must be 'reader' or 'artist'.");
            }
        }
        return await _repository.AddAsync(entity);
    }

}