using BlazorCRUDApp.Shared.Shared;
using BlazorCRUDApp.Shared.Interfaces;
using System.Net.Http.Json;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpService _httpService;
        public ProductService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<ServiceResponse<List<Product>>> GetAllProductsAsync()
        {
            var response = await _httpService.GetAsync<List<Product>>("api/Product");
            return response;
        }

    }
}
