using BlazorCRUDApp.Shared.Interfaces;
using BlazorCRUDApp.Shared.Responses;
using BlazorCRUDApp.Shared.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<User>>> Register(User user)
        {
            var response = await _userService.Register(user);
            if (response.Data == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetByUsername(string username)
        {
            var response = await _userService.GetByUsername(username);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
