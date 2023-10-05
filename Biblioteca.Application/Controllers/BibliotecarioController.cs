using Biblioteca.Application.Filters;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Data;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("bibliotecarios")]
    [TypeFilter(typeof(ExceptionFilter))]
    [Authorize]
    public class BibliotecarioController : ControllerBase
    {
        private readonly IBibliotecarioService _bibliotecarioService;
        private readonly ILoginService _loginService;

        public BibliotecarioController(IBibliotecarioService bibliotecarioService, ILoginService loginService)
        {
            _bibliotecarioService = bibliotecarioService;
            _loginService = loginService;
        }

        [HttpPost]
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Add(AddBibliotecarioRequest teste)
        {
            await _bibliotecarioService.Add(teste);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? cpf, string? name)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (!string.IsNullOrEmpty(cpf))
            {
                Bibliotecario? result = await _bibliotecarioService.GetByCpf(cpf);
                result?.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE);
                return Ok(result);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                List<Bibliotecario> results = await _bibliotecarioService.GetByName(name);
                results.ForEach(result => result.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE));
                return Ok(results);
            }
            else
            {
                List<Bibliotecario> results = await _bibliotecarioService.GetAll();
                results.ForEach(result => result.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE));
                return Ok(results);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ulong id)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            Bibliotecario? result = await _bibliotecarioService.GetById(id);
            result?.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Update(ulong id, [FromBody] UpdateBibliotecarioRequest bibliotecario)
        {
            if (bibliotecario == null)
                return BadRequest();

            bibliotecario.Id = id;
            await _bibliotecarioService.Update(bibliotecario);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Delete(ulong id)
        {
            await _bibliotecarioService.Delete(id);
            return Ok();
        }
    }
}