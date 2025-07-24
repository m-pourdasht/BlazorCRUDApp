using AutoMapper;
using BlazorCRUDApp.Server.UnitOfWork;
using BlazorCRUDApp.Shared.Dtos;
using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;

namespace BlazorCRUDApp.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Repository<CategoryDto>().GetAllAsync();
            return new ServiceResponse<List<CategoryDto>> { Data = categories };
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid category ID", nameof(id));
            }
            return await _unitOfWork.Repository<CategoryDto>().GetById(id);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid category ID", nameof(id));
            }
            var category = await _unitOfWork.Repository<CategoryDto>().GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found");
            }
            _unitOfWork.Repository<CategoryDto>().Delete(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateCategoryAsync(CategoryCreateDto category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            await _unitOfWork.Repository<CategoryCreateDto>().Add(category);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateCategoryAsync(CategoryUpdateDto category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            var existingCategory = await _unitOfWork.Repository<CategoryUpdateDto>().GetById(category.Id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {category.Id} not found");
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
