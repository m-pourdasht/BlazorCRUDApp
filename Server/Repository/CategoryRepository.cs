//It interacts directly with the database through EF Core.

using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Server.Repository.Interfaces;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _context.Categories.ToListAsync();
        }
    }
}
