using BlazorCRUDApp.Shared.Dtos;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Shared.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync();
        Task CreateProductAsync(ProductCreateDto product);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task UpdateProductAsync(ProductUpdateDto product);
        Task DeleteProductAsync(int id);
    }
}
