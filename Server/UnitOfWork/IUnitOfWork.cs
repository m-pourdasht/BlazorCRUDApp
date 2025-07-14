using BlazorCRUDApp.Server.Repository.Interfaces;

namespace BlazorCRUDApp.Server.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
