using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Dtos;

namespace BlazorCRUDApp.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpService _httpService;
        public ProductService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync()
        {
            return await _httpService.Get<ServiceResponse<List<ProductDto>>>("api/product");
        }
        public async Task CreateProductAsync(ProductCreateDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            await _httpService.Post("api/product", product);
        }
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }
            return await _httpService.Get<ProductDto>($"api/product/{id}");
        }
        public
            async Task UpdateProductAsync(ProductUpdateDto product)
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
