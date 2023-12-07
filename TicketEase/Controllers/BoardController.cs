﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketEase.Application.DTO;
using TicketEase.Application.Interfaces.Services;
using TicketEase.Application.ServicesImplementation;
using TicketEase.Domain;

namespace TicketEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardServices _boardServices;
        public BoardController(IBoardServices boardServices)
        {
            _boardServices = boardServices;
        }

        //[Authorize(Roles = "Admin, Manager")]
        [HttpPost("AddBoard")]
        public async Task<IActionResult> AddBoard([FromBody] BoardRequestDto request)
            => Ok(await _boardServices.AddBoardAsync(request));
    }
}