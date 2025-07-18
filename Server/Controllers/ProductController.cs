using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context; 
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> Get()
        {
            var response = new ServiceResponse<List<Product>>();
            try
            {
                response.Data = await _context.Products.ToListAsync();
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Product>>> Create(Product product)
        {
            var response = new ServiceResponse<Product>();
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product cannot be null");
                }
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                response.Data = product;
                response.Success = true;
                return CreatedAtAction(nameof(Get), new { id = product.Id }, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}