using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Dtos;

namespace BlazorCRUDApp.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpService _httpService;
        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            return await _httpService.Get<ServiceResponse<List<CategoryDto>>>("api/category");
        }
        public async Task CreateCategoryAsync(CategoryCreateDto category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            await _httpService.Post("api/category", category);
        }
        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid categoryDto ID", nameof(id));
            }
            return await _httpService.Get<CategoryDto>($"api/categoryDto/{id}");
        }
        public async Task UpdateCategoryAsync(CategoryUpdateDto category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            if (category.Id <= 0)
            {
                throw new ArgumentException("Invalid Category ID", nameof(category.Id));
            }
            await _httpService.Put("api/category", category);
        }

        public Task DeleteCategoryAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid category ID", nameof(id));
            }
            return _httpService.Delete($"api/category/{id}");
        }
    }
}
