using Domain.Monetization.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure.Persistence.EFC.Configuration.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Commision> Commisions { get; set; }
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
        
    }
}