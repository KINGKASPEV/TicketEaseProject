using Microsoft.AspNetCore.Mvc;
using Serilog;
using TicketEase.Application.DTO;
using TicketEase.Application.DTO.Manager;
using TicketEase.Application.DTO.Project;
using TicketEase.Application.Interfaces.Services;
using TicketEase.Application.ServicesImplementation;
using TicketEase.Domain;

namespace TicketEase.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerServices _managerService;
        private readonly IProjectServices _projectService;

        public ManagerController(IManagerServices managerService, IProjectServices projectService)
        {
            _managerService = managerService;
            _projectService = projectService;
        }

        [HttpPost("AddManager")]
        public async Task<IActionResult> CreateManager([FromBody] ManagerInfoCreateDto managerInfoCreateDto)
        {
            return Ok(await _managerService.CreateManager(managerInfoCreateDto));
        }
    }
}