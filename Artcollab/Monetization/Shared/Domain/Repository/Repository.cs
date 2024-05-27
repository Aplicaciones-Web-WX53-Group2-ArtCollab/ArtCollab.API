using Application.Monetization.Shared.Domain.Interfaces;
using Application.Monetization.Shared.Infrastructure.Persistence.EFC.Configuration.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Monetization.Shared.Domain.Repository;

public class Repository<TEntity>(AppDbContext context): IBaseRepository<TEntity> where TEntity : class 
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();


    public async Task AddAsync(TEntity entity)
    {
        var strategy = _context.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbSet.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(e.Message);
                }
            }
        });
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Update(TEntity entity)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbSet.Update(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(e.Message);
                }
            }
        });
    }

    public async Task Remove(TEntity entity)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(e.Message);
                }
            }
        });
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }
}