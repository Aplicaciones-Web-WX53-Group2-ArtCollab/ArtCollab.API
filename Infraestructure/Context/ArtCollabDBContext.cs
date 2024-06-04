using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class ArtCollabDBContext : DbContext
{
    public ArtCollabDBContext()
    {
        
    }
    public ArtCollabDBContext(DbContextOptions<ArtCollabDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=12345678;Database=ArtCollab",
                serverVersion);
        }
    }
    
protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Comment>().ToTable("Comment");
        
    }
}
