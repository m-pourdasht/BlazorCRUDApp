using BlazorCRUDApp.Server.UnitOfWork;
using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Server.Services;
using BlazorCRUDApp.Shared.Shared;
using System.Net.Http.Json;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<List<Product>>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return new ServiceResponse<List<Product>> { Data = products };
        }
    }
}
