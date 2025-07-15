//It manages the connection to the database and maps your C# classes (Product, Category, etc.) to database tables.
//EF Core class that manages tables (DbSet) and database connection settings.
using BlazorCRUDApp.Client.Pages;
using BlazorCRUDApp.Shared.Shared;
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
    }
}
