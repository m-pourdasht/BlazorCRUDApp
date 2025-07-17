//It is used to manage dependencies and transactions between repositories.

using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Server.Repository;
using BlazorCRUDApp.Server.Repository.Interfaces;

namespace BlazorCRUDApp.Server.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<string, object> _repositories = new();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            var typeName = typeof(T).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repositoryInstance = new Repository<T>(_context);
                _repositories.Add(typeName, repositoryInstance);
            }
            return (IRepository<T>)_repositories[typeName];
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                // Log the exception or handle it as needed
                return false;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
