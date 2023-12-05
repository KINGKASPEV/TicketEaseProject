using Microsoft.AspNetCore.Mvc;
using TicketEase.Application.DTO;
using TicketEase.Application.DTO.Project;
using TicketEase.Application.Interfaces.Services;
using TicketEase.Domain;

namespace TicketEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Route("api/users")]

    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var response = await _userServices.GetUserByIdAsync(userId);

            if (response.Succeeded)
            {
                return Ok(response.Data);
            }

            return StatusCode(response.StatusCode, new { errors = response.Errors });
        }

        [HttpGet("get-Users-By-Pagination")]
        public async Task<IActionResult> GetUsersByPagination(int page, int perPage)
        {
            var response = await _userServices.GetUsersByPaginationAsync(page, perPage);

            if (response.Succeeded)
            {
                return Ok(response.Data);
            }

            return StatusCode(response.StatusCode, new { errors = response.Errors });
        }
    }
}