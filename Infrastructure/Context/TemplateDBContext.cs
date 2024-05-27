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
            
            builder.Entity<Template>().ToTable("Templates");
            
            builder.Entity<Template>().HasKey(x => x.Id);
            
            builder.Entity<Template>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Template>().Property(x => x.Title).IsRequired();
            builder.Entity<Template>().Property(x => x.Description).IsRequired();
            builder.Entity<Template>().Property(x => x.Date_Publish).IsRequired();
            builder.Entity<Template>().Property(x => x.Type).IsRequired();
            builder.Entity<Template>().Property(x => x.ImgUrl).IsRequired();
            builder.Entity<Template>().Property(x => x.TemplateState_Id).IsRequired();
            builder.Entity<Template>().Property(x => x.TemplateHistory_Id).IsRequired();
            builder.Entity<Template>().Property(x => x.Portfolio_Id).IsRequired();
            builder.Entity<Template>().Property(x => x.Genre);
        }
    }
}