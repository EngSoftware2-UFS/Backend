using Biblioteca.Application.Filters;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("bibliotecarios")]
    [TypeFilter(typeof(ExceptionFilter))]
    [Authorize(Roles = "BIBLIOTECARIO")]
    public class BibliotecarioController : ControllerBase
    {
        private readonly IBibliotecarioService _bibliotecarioService;

        public BibliotecarioController(IBibliotecarioService bibliotecarioService)
        {
            _bibliotecarioService = bibliotecarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBibliotecarioRequest teste)
        {
            await _bibliotecarioService.Add(teste);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? cpf, string? name)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                Bibliotecario? result = await _bibliotecarioService.GetByCpf(cpf);
                return Ok(result);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                List<Bibliotecario> results = await _bibliotecarioService.GetByName(name);
                return Ok(results);
            }
            else
            {
                List<Bibliotecario> results = await _bibliotecarioService.GetAll();
                return Ok(results);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ulong id)
        {
            Bibliotecario? results = await _bibliotecarioService.GetById(id);
            return Ok(results);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(ulong id, [FromBody] UpdateBibliotecarioRequest bibliotecario)
        {
            if (bibliotecario == null)
                return BadRequest();

            bibliotecario.Id = id;
            await _bibliotecarioService.Update(bibliotecario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            await _bibliotecarioService.Delete(id);
            return Ok();
        }
    }
}