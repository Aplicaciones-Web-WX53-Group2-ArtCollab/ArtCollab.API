using Domain.Interface;
using Domain.Monetization.Model.Aggregates;
using Infraestructure.Interfaces;
using Infraestructure.Monetization.Model.Aggregates;

namespace Domain.Repository
{
    public class RepositoryGeneric<TEntity>(IRepository<TEntity> repository): IRepositoryGeneric<TEntity> where TEntity : class
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
            if (entity is Commision commision)
            {
                if (commision.Content == string.Empty || commision.Content == null)
                {
                    throw new Exception("Content is required for a commision");
                }

                if (commision.Amount <0)
                {
                    throw new Exception("Amount must be greater than 0");
                }
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
}