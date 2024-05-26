using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MySql;

public class Repository<TEntity>(ArtCollabDbContext context) : IRepository<TEntity> where TEntity : BaseModel
{
    private readonly ArtCollabDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.Where(i=>i.IsActive).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.Where(i=>i.IsActive && i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddAsync(TEntity entity)
    {
        entity.IsActive = true;
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
                throw;
            }
        }
        return entity.Id;
    }

    public async Task UpdateAsync(TEntity entity, int id)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var entityToUpdate = await _dbSet.Where(i=>i.IsActive && i.Id == id).FirstOrDefaultAsync();
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var entity = await _dbSet.FindAsync(id);
            entity.IsActive = false;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}