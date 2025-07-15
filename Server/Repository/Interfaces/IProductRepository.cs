//The business logic is implemented in this section. This layer is located between the Controller and the Repository.
using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Server.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllAsync();
    }
}
