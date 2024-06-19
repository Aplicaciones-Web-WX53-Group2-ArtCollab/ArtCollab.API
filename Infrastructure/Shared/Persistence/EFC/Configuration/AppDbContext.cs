using Domain.Collaboration.Model.Aggregates;
using Domain.Content.Model.Aggregates;
using Domain.Monetization.Model.Aggregates;
using Domain.User.Model.Aggregates;
using Infrastructure.Monetization.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Commision> Commisions { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Reader> Readers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Subscription>().ToTable("subscriptions");
        builder.Entity<Subscription>().HasKey(s => s.Id);
        builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().Property(s => s.IsActive).IsRequired();
        
        
        builder.Entity<Commision>().ToTable("commisions");
        builder.Entity<Commision>().HasKey(c => c.Id);
        builder.Entity<Commision>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Commision>().Property(c => c.Amount).IsRequired();
        builder.Entity<Commision>().Property(c => c.Content).IsRequired();
        builder.Entity<Commision>().Property(c => c.Date).IsRequired();
        
        builder.Entity<Template>().ToTable("templates");
        builder.Entity<Template>().HasKey(t => t.Id);
        builder.Entity<Template>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Template>().Property(t => t.Description).IsRequired();
        builder.Entity<Template>().Property(t => t.Genre).IsRequired();
        builder.Entity<Template>().Property(t => t.IsActive).IsRequired();
        builder.Entity<Template>().Property(t => t.Title).IsRequired();
        builder.Entity<Template>().Property(t => t.Type).IsRequired();
        builder.Entity<Template>().Property(t => t.ImgUrl).IsRequired();
        
        
        builder.Entity<Reader>().ToTable("readers");
        builder.Entity<Reader>().HasKey(r => r.Id);
        builder.Entity<Reader>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reader>().Property(r => r.Name).IsRequired();
        builder.Entity<Reader>().Property(r => r.UserName).IsRequired();
        builder.Entity<Reader>().Property(r => r.Email).IsRequired();
        builder.Entity<Reader>().Property(r => r.Password).IsRequired();
        builder.Entity<Reader>().Property(r => r.Type).IsRequired();
        builder.Entity<Reader>().Property(r => r.ImgUrl).IsRequired();

        builder.Entity<Comment>().ToTable("comments");
        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comment>().Property(c => c.Content).IsRequired();
        builder.Entity<Comment>().Property(c => c.Date).IsRequired();




    }
}