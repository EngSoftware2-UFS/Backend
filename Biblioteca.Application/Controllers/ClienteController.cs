using Biblioteca.Application.Filters;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enums;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("clientes")]
    [TypeFilter(typeof(ExceptionFilter))]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILoginService _loginService;

        public ClienteController(IClienteService clienteService, ILoginService loginService)
        {
            _clienteService = clienteService;
            _loginService = loginService;
        }

        [HttpPost]
        [Authorize(Roles = "ATENDENTE,BIBLIOTECARIO")]
        public async Task<IActionResult> Add(AddClienteRequest teste)
        {
            await _clienteService.Add(teste);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "ATENDENTE,BIBLIOTECARIO")]
        public async Task<IActionResult> Get(string? cpf, string? name)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                Cliente? result = await _clienteService.GetByCpf(cpf);
                return Ok(result);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                List<Cliente> results = await _clienteService.GetByName(name);
                return Ok(results);
            }
            else
            {
                List<Cliente> results = await _clienteService.GetAll();
                return Ok(results);
            }
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> Get(ulong idCliente)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);
            
            if (loggedUser != null 
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            Cliente? results = await _clienteService.GetById(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/reservas")]
        public async Task<IActionResult> GetReservas(ulong idCliente)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (loggedUser != null
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            List<ReservaResponse> results = await _clienteService.GetReservas(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/reservas/historico")]
        public async Task<IActionResult> GetHistoricoReservas(ulong idCliente)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (loggedUser != null
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            List<ReservaResponse> results = await _clienteService.GetHistoricoReservas(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/reservas/{idReserva}")]
        public async Task<IActionResult> GetReserva(ulong idCliente, ulong idReserva)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (loggedUser != null
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            ReservaResponse? results = await _clienteService.GetReserva(idCliente, idReserva);
            return Ok(results);
        }

        [HttpGet("{idCliente}/emprestimos")]
        public async Task<IActionResult> GetEmprestimos(ulong idCliente)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (loggedUser != null
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            List<EmprestimoResponse> results = await _clienteService.GetEmprestimos(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/emprestimos/historico")]
        public async Task<IActionResult> GetHistoricoEmprestimos(ulong idCliente)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (loggedUser != null
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            List<EmprestimoResponse> results = await _clienteService.GetHistoricoEmprestimos(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/emprestimos/{idEmprestimo}")]
        public async Task<IActionResult> GetEmprestimo(ulong idCliente, ulong idEmprestimo)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (loggedUser != null
                && loggedUser.TipoUsuario == ETipoUsuario.CLIENTE
                && loggedUser.Id != idCliente)
                return NotFound();

            EmprestimoResponse? results = await _clienteService.GetEmprestimo(idCliente, idEmprestimo);
            return Ok(results);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "ATENDENTE,BIBLIOTECARIO")]
        public async Task<IActionResult> Update(ulong id, [FromBody] UpdateClienteRequest cliente)
        {
            if (cliente == null)
                return BadRequest();

            cliente.Id = id;
            await _clienteService.Update(cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Delete(ulong id)
        {
            await _clienteService.Delete(id);
            return Ok();
        }
    }
}