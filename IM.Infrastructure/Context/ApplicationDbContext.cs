using IM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IM.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
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
