using Domain.Interface;
using Domain.Monetization.Model.Aggregates;
using Infraestructure.Interfaces;
using Infraestructure.Monetization.Model.Aggregates;
using Infraestructure.Monetization.Model.Entities;

namespace Domain.Repository
{
    public class RepositoryGeneric<TEntity>(IRepository<TEntity> repository, Observer observer): IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository = repository;
        private Observer _observer = observer;
    
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
            if (entity is Commision commision)
            {
                if (commision.Content == string.Empty || commision.Content == null)
                {
                    throw new Exception("Content is required for a commision");
                }

                if (commision.Amount < 0)
                {
                    throw new Exception("Amount must be greater than 0");
                }
            }
            await _repository.Add(entity);
        }

        public async Task Update(TEntity entity)
        {
            if (entity is Subscription subscription)
            {
                var responseObserver = _observer.Update();
                if (responseObserver.IsSuccessStatusCode)
                {
                 await _repository.Update(entity);
                }
                else
                {
                    throw new Exception("Error updating subscription");
                }
            }
            else
            {
                await _repository.Update(entity);
            }
            
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}