using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Server.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllAsync();
    }
}
