using Biblioteca.Application.Filters;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("emprestimos")]
    [TypeFilter(typeof(ExceptionFilter))]
    [Authorize]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly ILoginService _loginService;

        public EmprestimosController(IEmprestimoService emprestimoService, ILoginService loginService)
        {
            _emprestimoService = emprestimoService;
            _loginService = loginService;
        }

        [HttpGet]
        [Authorize(Roles = "ATENDENTE")]
        public async Task<IActionResult> Get(string? nomeCliente, string? status)
        {
            if (string.IsNullOrEmpty(nomeCliente))
            {
                var emprestimos = await _emprestimoService.GetEmprestimos(status);
                return Ok(emprestimos);
            }
            else
            {
                var emprestimos = await _emprestimoService.GetEmprestimosByClient(nomeCliente, status);
                return Ok(emprestimos);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ATENDENTE")]
        public async Task<IActionResult> Post(CriarEmprestimoRequest request)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);
            if (loggedUser == null)
                return NotFound();

            request.setAtendente(loggedUser.Id);
            await _emprestimoService.CriarEmprestimo(request);
            return Ok();
        }

        [HttpPatch("{emprestimoId}/cancelar")]
        [Authorize(Roles = "ATENDENTE")]
        public async Task<IActionResult> Cancelar(ulong emprestimoId)
        {
            await _emprestimoService.CancelarEmprestimo(emprestimoId);
            return Ok();
        }

        [HttpPatch("{emprestimoId}/renovar")]
        [Authorize(Roles = "CLIENTE,ATENDENTE")]
        public async Task<IActionResult> Renovar(ulong emprestimoId)
        {
            await _emprestimoService.RenovarEmprestimo(emprestimoId);
            return Ok();
        }

        [HttpPatch("{emprestimoId}/devolver")]
        [Authorize(Roles = "ATENDENTE")]
        public async Task<IActionResult> Devolver(ulong emprestimoId)
        {
            await _emprestimoService.Devolver(emprestimoId);
            return Ok();
        }

        [HttpPatch("{emprestimoId}/pagarMulta")]
        [Authorize(Roles = "ATENDENTE")]
        public async Task<IActionResult> PagarMulta(ulong emprestimoId)
        {
            await _emprestimoService.PagarMultaEDevolver(emprestimoId);
            return Ok();
        }
    }
}
