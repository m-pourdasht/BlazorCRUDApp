using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAll()
        {
            var result = await _productService.GetAllProductsAsync();
            if (result.Success)
                return Ok(result);
            result.Success = false;
            return BadRequest(result);
        }
    }
}
