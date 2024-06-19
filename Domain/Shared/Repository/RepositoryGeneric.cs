using System.Data;
using Domain.Interfaces;
using Infrastructure.Content.Interfaces;
using Infrastructure.Monetization.Model.Aggregates;
using Infrastructure.Shared.Exceptions;
using Infrastructure.Shared.Interfaces;
using Infrastructure.Users.Interfaces;
using Infrastructure.Users.Model;

namespace Domain.Repository
{
    public class RepositoryGeneric<TEntity>(IRepository<TEntity> repository, Observer observer, IReaderData readerData): IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository = repository;
        private Observer _observer = observer;
        private readonly IReaderData _readerData = readerData;
        

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity is Reader reader)
            {
                var existingReaderByUserName = await _readerData.GetByUserNameAsync(reader.UserName);
                if (existingReaderByUserName != null)
                {
                    throw new DuplicateNameException("A reader with the same username already exists.");
                }

                var existingReaderByEmail = await _readerData.GetByEmailAsync(reader.Email);
                if (existingReaderByEmail != null)
                {
                    throw new DuplicateNameException("A reader with the same email already exists.");
                }

                var readerType = reader.Type.ToLower();
                if (readerType != "reader" && readerType != "artist")
                {
                    throw new InvalidTypeReaderException("Invalid reader type: Must be 'reader' or 'artist'.");
                }
            }

            if (entity is Commision commision)
            {
                if (string.IsNullOrEmpty(commision.Content))
                {
                    throw new ArgumentException("Content is required for a commision");
                }

                if (commision.Amount < 0)
                {
                    throw new ArgumentException("Amount must be greater than 0");
                }
            }
            await _repository.AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            if (entity is Subscription subscription)
            {
                var responseObserver = _observer.Update();
                if (responseObserver.IsSuccessStatusCode)
                {
                    await _repository.UpdateAsync(entity);
                }
                else
                {
                    throw new NoIdFoundException("Error updating subscription");
                }
            }

            else
            {
                await _repository.UpdateAsync(entity);
            }
            
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}