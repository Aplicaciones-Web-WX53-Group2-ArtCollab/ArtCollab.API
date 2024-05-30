using Infraestructure.Content.Interfaces;
using Infraestructure.Context;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Content.MySql;

public class TemplateMySqlData<TEntity>(TemplateDBContext context) : ITemplateData<TEntity> where TEntity : class
{
    private readonly TemplateDBContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    
    public async Task<IEnumerable<Template>> GetByGenreAsync(string genre)
    {
        return await _context.Templates.Where(i => i.Genre == genre).ToListAsync();
    }
}