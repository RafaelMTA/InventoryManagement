using IM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IM.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Product>()
            .HasMany(e => e.Inventories)
            .WithMany(e => e.Products)
            .UsingEntity<ProductInventory>(
                b => b.HasOne<Inventory>().WithMany().HasForeignKey("InventoryId"),
                b => b.HasOne<Product>().WithMany().HasForeignKey("ProductId")
            );

            modelBuilder
            .Entity<Order>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Orders)
            .UsingEntity<ProductOrder>(
                b => b.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                b => b.HasOne<Order>().WithMany().HasForeignKey("OrderId")
            );

            modelBuilder
            .Entity<Product>()
            .OwnsOne(p => p.Price);

            modelBuilder
            .Entity<Inventory>()
            .OwnsOne(p => p.Price);

            modelBuilder
            .Entity<Order>()
            .OwnsOne(p => p.OrderDetails);

            modelBuilder
            .Entity<OrderDetails>()
            .OwnsOne(p => p.ShippingAddress);

            modelBuilder
            .Entity<OrderDetails>()
            .OwnsOne(p => p.Payment);

            modelBuilder
            .Entity<Company>()
            .OwnsOne(p => p.Address);

            modelBuilder
            .Entity<Company>()
            .OwnsOne(p => p.Contact);

            modelBuilder
            .Entity<User>()
            .OwnsOne(p => p.UserDetails);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
