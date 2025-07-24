using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCRUDApp.Shared.Dtos;

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

            var response = new ServiceResponse<List<ProductDto>>();
            try
            {
                var products = await _context.Products
                    .Include(p => p.Category)
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        CategoryId = p.CategoryId,
                        CategoryName = p.Category.Name // ✅ This is the key!
                    }).ToListAsync();

                response.Data = products;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductById(int id)
        {
            var response = new ServiceResponse<Product>();
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product not found";
                    return NotFound(response);
                }
                response.Data = product;
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

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDto product)
        {
            var response = new ServiceResponse<Product>();
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product cannot be null");
                }
                var existingProduct = await _context.Products.FindAsync(product.Id);
                if (existingProduct == null)
                {
                    response.Success = false;
                    response.Message = "Product not found";
                    return NotFound(response);
                }
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();

                response.Data = existingProduct;
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> Delete(int id)
        {
            var response = new ServiceResponse<Product>();
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Product not found";
                    return NotFound(response);
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                response.Data = product;
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
    }
}