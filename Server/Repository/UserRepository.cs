using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Server.Repository.Interfaces;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<User> CreateAsync(User _object)
        {
            throw new NotImplementedException();
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public Task DeleteAsync(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }
        public async Task<List<User>> GetAllAsync(string username)
        {
            return await _context.Users.Where(u => u.UserName.Contains(username)).ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public Task<User?> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(User _object)
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetUserAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public Task<User> GetByUsernameAsync(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
