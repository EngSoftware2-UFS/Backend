using Biblioteca.Application.Filters;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enums;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("reservas")]
    [TypeFilter(typeof(ExceptionFilter))]
    [Authorize]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly ILoginService _loginService;

        public ReservaController(IReservaService reservaService, ILoginService loginService)
        {
            _reservaService = reservaService;
            _loginService = loginService;
        }

        [HttpGet]
        [Authorize(Roles = "ATENDENTE")]
        public async Task<IActionResult> Get(string? nomeCliente, string? status)
        {
            if (string.IsNullOrEmpty(nomeCliente))
            {
                var reservas = await _reservaService.GetReservas(status);
                return Ok(reservas);
            }
            else
            {
                var reservas = await _reservaService.GetReservasByClient(nomeCliente, status);
                return Ok(reservas);
            }
        }

        [HttpPost]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Post(CriarReservaRequest request)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);
            if (loggedUser == null)
                return NotFound();

            request.setClientId(loggedUser.Id);
            await _reservaService.CriarReserva(request);
            return Ok();
        }

        [HttpPatch("{reservaId}/cancelar")]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Cancelar(ulong reservaId)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);
            if (loggedUser == null)
                return NotFound();

            var request = new CancelarReservaRequest(loggedUser.Id, reservaId);
            await _reservaService.CancelarReserva(request);
            return Ok();
        }
    }
}
