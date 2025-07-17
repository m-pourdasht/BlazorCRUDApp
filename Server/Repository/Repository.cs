using BlazorCRUDApp.Server.Repository.Interfaces;
using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T?> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
