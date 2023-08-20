using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendenteController : ControllerBase
    {
        private readonly IAtendenteService _atendenteService;

        public AtendenteController(IAtendenteService atendenteService)
        {
            _atendenteService = atendenteService;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> Get()
        {
            List<GetAtendenteResponse> results = await _atendenteService.GetAll();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAtendenteRequest teste)
        {
            await _atendenteService.Add(teste);
            return Ok();
        }
    }
}