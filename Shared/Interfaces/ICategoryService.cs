using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Shared.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetAllCategoryAsync();
    }
}
