using BlazorCRUDApp.Server.UnitOfWork;
using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Dtos;
using BlazorCRUDApp.Shared.Responses;
using AutoMapper;


namespace BlazorCRUDApp.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<ProductDto>().GetAllAsync();
            return new ServiceResponse<List<ProductDto>> { Data = products };
        }
        public async Task CreateProductAsync(ProductCreateDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            await _unitOfWork.Repository<ProductCreateDto>().Add(product);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }
            return await _unitOfWork.Repository<ProductDto>().GetById(id);
        }
        public async Task UpdateProductAsync(ProductUpdateDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            var existingProduct = await _unitOfWork.Repository<ProductUpdateDto>().GetById(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found");
            }
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID", nameof(id));
            }
            var product = await _unitOfWork.Repository<ProductDto>().GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }
            _unitOfWork.Repository<ProductDto>().Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
