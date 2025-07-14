using BlazorCRUDApp.Server.Repository.Interfaces;
using BlazorCRUDApp.Server.UnitOfWork;
using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;

namespace BlazorCRUDApp.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<Category>>> GetAllCategoryAsync()
        {
            var response = new ServiceResponse<List<Category>>();
            response.Data = await _unitOfWork.CategoryRepository.GetAllAsync();
            response.Success = true;
            return response;
        }
    }
}
