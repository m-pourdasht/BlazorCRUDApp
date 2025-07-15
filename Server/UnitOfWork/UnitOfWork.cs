//It is used to manage dependencies and transactions between repositories.

using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Server.Repository;
using BlazorCRUDApp.Server.Repository.Interfaces;
using BlazorCRUDApp.Server.Repository.Repositories;

namespace BlazorCRUDApp.Server.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
