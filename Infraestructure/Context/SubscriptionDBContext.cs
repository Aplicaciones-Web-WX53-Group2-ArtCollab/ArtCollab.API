using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class SubscriptionDBContext(DbContextOptions<SubscriptionDBContext> options) : DbContext(options)
    {
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(9, 0, 29));
                optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=12345678;Database=ArtCollabDb",
                    serverVersion);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Subscription>().ToTable("Subscription");
        }
    }
}