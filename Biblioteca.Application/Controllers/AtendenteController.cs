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
        private readonly ILoginService _loginService;

        public AtendenteController(IAtendenteService atendenteService, ILoginService loginService)
        {
            _atendenteService = atendenteService;
            _loginService = loginService;
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
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            if (!string.IsNullOrEmpty(cpf))
            {
                AtendenteResponse? result = await _atendenteService.GetByCpf(cpf);
                result?.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE);
                return Ok(result);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                List<AtendenteResponse> results = await _atendenteService.GetByName(name);
                results.ForEach(result => result.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE));
                return Ok(results);
            }
            else
            {
                List<AtendenteResponse> results = await _atendenteService.GetAll();
                results.ForEach(result => result.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE));
                return Ok(results);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ulong id)
        {
            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);

            AtendenteResponse? result = await _atendenteService.GetById(id);
            result?.MaskCpf(loggedUser?.TipoUsuario == Domain.Enums.ETipoUsuario.ATENDENTE);
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