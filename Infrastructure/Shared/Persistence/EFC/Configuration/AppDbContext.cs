using Domain.Collaboration.Model.Aggregates;
using Domain.Content.Model.Aggregates;
using Domain.Content.Model.Entities;
using Domain.IAM.Model.Aggregates;
using Domain.Monetization.Model.Aggregates;
using Domain.User.Model.Aggregates;
using Infrastructure.Shared.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Commision> Commisions { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<TemplateState> TemplateStates { get; set; }
    
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
        builder.Entity<Template>().Property(t => t.Title).IsRequired();
        builder.Entity<Template>().Property(t => t.Type).IsRequired();
        builder.Entity<Template>().Property(t => t.ImgUrl).IsRequired();
        builder.Entity<Template>().Property(t => t.PortfolioId).IsRequired();
        
        
        builder.Entity<Reader>().ToTable("readers");
        builder.Entity<Reader>().HasKey(r => r.Id);
        builder.Entity<Reader>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reader>().Property(r => r.Name).IsRequired();
        builder.Entity<Reader>().Property(r => r.Username).IsRequired();
        builder.Entity<Reader>().Property(r => r.Email).IsRequired();
        builder.Entity<Reader>().Property(r => r.Password).IsRequired();
        builder.Entity<Reader>().Property(r => r.Type).IsRequired();
        builder.Entity<Reader>().Property(r => r.ImgUrl).IsRequired();
        
        builder.Entity<Portfolio>().ToTable("portfolios");
        builder.Entity<Portfolio>().HasKey(p => p.Id);
        builder.Entity<Portfolio>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Portfolio>().Property(p => p.Description).IsRequired();
        builder.Entity<Portfolio>().Property(p => p.Title).IsRequired();
        builder.Entity<Portfolio>().Property(p =>p.Quantity).IsRequired();
        builder.Entity<Template>().HasOne(t => t.Portfolio).WithMany(p => p.Templates)
            .HasForeignKey(t => t.PortfolioId);

        builder.Entity<TemplateState>().ToTable("template_states");
        builder.Entity<TemplateState>().HasKey(ts => ts.Id);
        builder.Entity<TemplateState>().Property(ts => ts.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TemplateState>().Property(ts => ts.Flag).IsRequired();
        builder.Entity<Template>().HasOne(s => s.TemplateState).WithMany(t => t.Templates)
            .HasForeignKey(t => t.TemplateStateId);

        builder.Entity<Comment>().ToTable("comments");
        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comment>().Property(c => c.Content).IsRequired();
        builder.Entity<Comment>().Property(c => c.Date).IsRequired();

        builder.Entity<Admin>().ToTable("admins");
        builder.Entity<Admin>().HasKey(a => a.Id);
        builder.Entity<Admin>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Admin>().Property(a => a.Username).IsRequired();
        builder.Entity<Admin>().Property(a => a.PasswordHash).IsRequired();

      builder.UseSnakeCaseWithPluralizedTableNamingConvention();


    }
}