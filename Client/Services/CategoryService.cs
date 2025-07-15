using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpService _httpService;
        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<ServiceResponse<List<Category>>> GetAllCategoryAsync()
        {
            var response = await _httpService.GetAsync<List<Category>>("api/Category");
            return response;
        }
    }
}
