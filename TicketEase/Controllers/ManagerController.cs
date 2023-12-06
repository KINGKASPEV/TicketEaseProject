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

        [HttpGet("GetById")]
        public IActionResult GetManagersById(string id)
        {
            var response = _managerService.GetManagerById(id);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public IActionResult EditManager(string id, EditManagerDto managerDTO)
        {
            var response = _managerService.EditManager(id, managerDTO);
            return Ok(response);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllManage(int page, int perPage)
        {
            var response = _managerService.GetAllManagerByPagination(page, perPage);
            return Ok(response);
        }

        [HttpPost("sendManagerInformation")]
        public async Task<IActionResult> SendManagerInformation(ManagerInfoCreateDto managerInfoCreateDto)
        {

            var response = await _managerService.SendManagerInformationToAdminAsync(managerInfoCreateDto);

            return Ok(response);
        }
    }
}