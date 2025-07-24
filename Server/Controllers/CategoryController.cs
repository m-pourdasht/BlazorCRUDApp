using BlazorCRUDApp.Server.Data;
using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Shared.Dtos;
using BlazorCRUDApp.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> Get()
        {
            var response = new ServiceResponse<List<Category>>();
            try
            {
                response.Data = await _context.Categories.ToListAsync();
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
        public async Task<ActionResult<ServiceResponse<Category>>> GetCategoryById(int id)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    response.Success = false;
                    response.Message = "Category not found";
                    return NotFound(response);
                }
                response.Data = category;
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
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDto category)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "Category cannot be null");
                }
                var existingCategory = await _context.Categories.FindAsync(category.Id);
                if (existingCategory == null)
                {
                    response.Success = false;
                    response.Message = "Category not found";
                    return NotFound(response);
                }
                existingCategory.Name = category.Name;

                _context.Categories.Update(existingCategory);
                await _context.SaveChangesAsync();

                response.Data = existingCategory;
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
        public async Task<ActionResult<ServiceResponse<Category>>> Create(Category category)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "Category cannot be null");
                }
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                response.Data = category;
                response.Success = true;
                return CreatedAtAction(nameof(Get), new { id = category.Id }, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Category>>> Delete(int id)
        {
            var response = new ServiceResponse<Category>();
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    response.Success = false;
                    response.Message = "Category not found";
                    return NotFound(response);
                }
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                response.Data = category;
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