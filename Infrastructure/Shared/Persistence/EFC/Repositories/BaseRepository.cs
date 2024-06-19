using Domain.Shared.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    public async  Task AddAsync(TEntity entity)
    { 
        using var transation = await context.Database.BeginTransactionAsync();
        try
        {
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                await transation.CommitAsync();
            }
        }
        catch (Exception e)
        {
            await context.Database.RollbackTransactionAsync();
            throw new Exception(e.Message);
        }
       
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>  await context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(long id) => await context.Set<TEntity>().FindAsync(id);
    

    public void Update(TEntity entity) => context.Set<TEntity>().Update(entity);
    

    public void Delete(TEntity entity) => context.Set<TEntity>().Remove(entity);
    
}