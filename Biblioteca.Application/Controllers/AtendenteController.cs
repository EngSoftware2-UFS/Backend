using Biblioteca.Application.Filters;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("atendentes")]
    [TypeFilter(typeof(ExceptionFilter))]
    [Authorize(Roles = "BIBLIOTECARIO")]
    public class AtendenteController : ControllerBase
    {
        private readonly IAtendenteService _atendenteService;

        public AtendenteController(IAtendenteService atendenteService)
        {
            _atendenteService = atendenteService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAtendenteRequest teste)
        {
            await _atendenteService.Add(teste);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? cpf, string? name)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                AtendenteResponse? result = await _atendenteService.GetByCpf(cpf);
                return Ok(result);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                List<AtendenteResponse> results = await _atendenteService.GetByName(name);
                return Ok(results);
            }
            else
            {
                List<AtendenteResponse> results = await _atendenteService.GetAll();
                return Ok(results);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ulong id)
        {
            AtendenteResponse? result = await _atendenteService.GetById(id);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(ulong id, [FromBody] UpdateAtendenteRequest atendente)
        {
            if (atendente == null)
                return BadRequest();

            atendente.Id = id;
            await _atendenteService.Update(atendente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            await _atendenteService.Delete(id);
            return Ok();
        }
    }
}