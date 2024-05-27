using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class BookDBContext(DbContextOptions<BookDBContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }

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
            
            builder.Entity<Book>().ToTable("Books");
            
            builder.Entity<Book>().HasKey(x => x.Id);
            
            builder.Entity<Book>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(x => x.Title).IsRequired();
            builder.Entity<Book>().Property(x => x.Description).IsRequired();
            builder.Entity<Book>().Property(x => x.Date_Publish).IsRequired();
            builder.Entity<Book>().Property(x => x.Type).IsRequired();
            builder.Entity<Book>().Property(x => x.ImgUrl).IsRequired();
            builder.Entity<Book>().Property(x => x.TemplateState_Id).IsRequired();
            builder.Entity<Book>().Property(x => x.TemplateHistory_Id).IsRequired();
            builder.Entity<Book>().Property(x => x.Portfolio_Id).IsRequired();
            builder.Entity<Book>().Property(x => x.Genre);
        }
    }
}