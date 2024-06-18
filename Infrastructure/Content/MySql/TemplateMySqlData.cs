using Infrastructure.Content.Interfaces;
using Infrastructure.Content.Models;
using Infrastructure.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.MySql;

public class TemplateMySqlData<TEntity>(AppDbContext context) : ITemplateData<TEntity> where TEntity : class
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    
    public async Task<IEnumerable<Template?>> GetByGenreAsync(string genre)
    {
        return await _context.Templates.Where(i => i.Genre == genre).ToListAsync();
    }
    
    public async Task<Template?> GetByDescriptionAsync(string description)
    {
        return await _context.Templates.FirstOrDefaultAsync(i => i.Description == description);
    }
    
    public async Task<Template> GetByCoverImageAsync(string imgUrl)
    {
        return await _context.Templates.FirstOrDefaultAsync(i => i.ImgUrl == imgUrl);
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }

    public async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
            
        await _context.SaveChangesAsync();
    }
}