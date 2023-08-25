using Biblioteca.Application.Filters;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("clientes")]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClienteRequest teste)
        {
            await _clienteService.Add(teste);
            return Ok();
        }

        [HttpGet]
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
            Cliente? results = await _clienteService.GetById(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/reservas")]
        public async Task<IActionResult> GetReservas(ulong idCliente)
        {
            List<Reserva> results = await _clienteService.GetReservas(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/reservas/historico")]
        public async Task<IActionResult> GetHistoricoReservas(ulong idCliente)
        {
            List<HistoricoReservas> results = await _clienteService.GetHistoricoReservas(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/reservas/{idReserva}")]
        public async Task<IActionResult> GetReserva(ulong idCliente, ulong idReserva)
        {
            Reserva? results = await _clienteService.GetReserva(idCliente, idReserva);
            return Ok(results);
        }

        [HttpGet("{idCliente}/emprestimos")]
        public async Task<IActionResult> GetEmprestimos(ulong idCliente)
        {
            List<Emprestimo> results = await _clienteService.GetEmprestimos(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/emprestimos/historico")]
        public async Task<IActionResult> GetHistoricoEmprestimos(ulong idCliente)
        {
            List<Emprestimo> results = await _clienteService.GetHistoricoEmprestimos(idCliente);
            return Ok(results);
        }

        [HttpGet("{idCliente}/emprestimos/{idEmprestimo}")]
        public async Task<IActionResult> GetEmprestimo(ulong idCliente, ulong idEmprestimo)
        {
            Emprestimo? results = await _clienteService.GetEmprestimo(idCliente, idEmprestimo);
            return Ok(results);
        }
    }
}