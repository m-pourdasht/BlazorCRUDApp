using BlazorCRUDApp.Shared.Dtos;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Shared.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CategoryCreateDto product);
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(CategoryUpdateDto product);
        Task DeleteCategoryAsync(int id);
    }
}
