using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class TemplateDBContext(DbContextOptions<TemplateDBContext> options) : DbContext(options)
    {
        public DbSet<Template> Templates { get; set; }
        public DbSet<Template_History> Template_Histories { get; set; }
        public DbSet<TemplateState> TemplateStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=12345678;Database=TemplateDB", serverVersion);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Template>().ToTable("Template");
            builder.Entity<Template_History>().ToTable("Template_History");
            builder.Entity<TemplateState>().ToTable("TemplateState");
        }
    }
}