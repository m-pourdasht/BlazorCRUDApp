//This pattern groups multiple repository operations under a single transaction.

using BlazorCRUDApp.Server.Repository.Interfaces;

namespace BlazorCRUDApp.Server.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
        Task<bool> SaveChangesAsync();
    }
}
