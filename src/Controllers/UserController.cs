using Microsoft.AspNetCore.Mvc;
using ShijiMiddlewareTask.ErrorHandling;
using ShijiMiddlewareTask.User.Services;

namespace ShijiMiddlewareTask.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Controller properties
        private readonly IUserService _userService;

        // Constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Endpoints
        [HttpGet("getNextId")]
        public async Task<IActionResult> GetNextId([FromQuery] string clientId)
        {
            try
            {
                return Ok(await _userService.GetNextId(clientId));
            }
            catch (ApiException e)
            {
                // I implemented my own error handling. Returns corresponding status code and error message thrown by the services
                return StatusCode(e.StatusCode, e.Message);
            }
        }
    }
}
