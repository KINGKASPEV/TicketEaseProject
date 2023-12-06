using Microsoft.AspNetCore.Mvc;
using TicketEase.Application.DTO;
using TicketEase.Application.Interfaces.Services;
using TicketEase.Domain;
using TicketEase.Domain.Enums;

namespace TicketEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("add-ticket")]
        public IActionResult AddTicket(string userId, string projectId, [FromBody] TicketRequestDto ticketRequestDTO)
        {
            var response = _ticketService.AddTicket(userId, projectId, ticketRequestDTO);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("edit-ticket/{ticketId}")]
        public IActionResult EditTicket(string ticketId, [FromBody] UpdateTicketRequestDto updatedTicketRequestDTO)
        {
            var response = _ticketService.EditTicket(ticketId, updatedTicketRequestDTO);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}