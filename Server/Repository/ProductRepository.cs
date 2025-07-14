using BlazorCRUDApp.Server.Repository.Interfaces;
using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
