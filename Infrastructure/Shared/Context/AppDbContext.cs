using Domain.Content.Models.Aggregate;
using Domain.Content.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Shared.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Commision> Commisions { get; set; }
    public DbSet<Template?> Templates { get; set; }
    public DbSet<TemplateHistory> TemplateHistories { get; set; }
    public DbSet<TemplateState> TemplateStates { get; set; }
    public DbSet<Reader?> Readers { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
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
        builder.Entity<Template>().Property(t => t.Date_Publish).IsRequired();
        builder.Entity<Template>().Property(t => t.TemplateState_id).IsRequired();
        builder.Entity<Template>().Property(t => t.TemplateHistory_id).IsRequired();
        builder.Entity<Template>().Property(t => t.Portfolio_id).IsRequired();
       
        
        builder.Entity<TemplateHistory>().ToTable("template_histories");
        builder.Entity<TemplateHistory>().HasKey(th => th.Id);
        builder.Entity<TemplateHistory>().Property(th => th.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TemplateHistory>().Property(th => th.Modified_at).IsRequired();
        builder.Entity<TemplateHistory>().Property(th => th.Delete_at).IsRequired();
        
        builder.Entity<TemplateState>().ToTable("template_states");
        builder.Entity<TemplateState>().HasKey(ts => ts.Id);
        builder.Entity<TemplateState>().Property(ts => ts.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TemplateState>().Property(ts => ts.Flag).IsRequired();
        
        
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
        builder.Entity<Comment>().Property(c => c.Image).IsRequired();
        builder.Entity<Comment>().Property(c => c.Likes).IsRequired();
        builder.Entity<Comment>().Property(c => c.Dislikes).IsRequired();
        builder.Entity<Comment>().Property(c => c.Name).IsRequired();




    }
}