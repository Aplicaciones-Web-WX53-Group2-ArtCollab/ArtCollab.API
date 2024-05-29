using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class TemplateDBContext(DbContextOptions<TemplateDBContext> options) : DbContext(options)
    {
        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //var serverVersion = 
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Template>().ToTable("Template");
        }
    }
}