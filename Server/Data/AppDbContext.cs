//It manages the connection to the database and maps your C# classes (Product, Category, etc.) to database tables.
//EF Core class that manages tables (DbSet) and database connection settings.
using BlazorCRUDApp.Client.Pages;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
