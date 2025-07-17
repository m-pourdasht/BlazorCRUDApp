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
            return await _httpService.Get<ServiceResponse<List<Product>>>("api/product");
        }
        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            await _httpService.Post("api/product", product);
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }
            return await _httpService.Get<Product>($"api/product/{id}");
        }
        public
            async Task UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            var existingProduct = await GetProductByIdAsync(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found");
            }
            await _httpService.Put("api/product", product);
        }

        public Task DeleteProductAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }
            return _httpService.Delete($"api/product/{id}");
        }
    }
}
