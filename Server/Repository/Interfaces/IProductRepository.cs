using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Server.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllAsync();
    }
}
