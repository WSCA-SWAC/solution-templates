using Microsoft.EntityFrameworkCore;
using WscaBaseSolution.Domain.Entities;
using WscaBaseSolution.Infrastructure.Interfaces;

namespace WscaBaseSolution.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IDomainEventDispatcher DomainEventDispatcher { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher domainEventDispatcher)
            : base(options)
        {
            DomainEventDispatcher = domainEventDispatcher;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .HasMany(o => o.Items)
                        .WithOne()
                        .HasForeignKey("OrderId");

            base.OnModelCreating(modelBuilder);
        }
    }
}
