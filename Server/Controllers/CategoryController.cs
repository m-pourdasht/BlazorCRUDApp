//This layer is located on the Server side and receives HTTP requests and forwards them to the Service.
using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAll()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            if (result.Success)
                return Ok(result);
            result.Success = false;
            return BadRequest(result);

        }
    }
}
