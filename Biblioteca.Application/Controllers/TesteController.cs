using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ITesteService _testeService;

        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> Get()
        {
            List<GetTesteResponse> results = await _testeService.GetAll();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTesteRequest teste)
        {
            await _testeService.Add(teste);
            return Ok();
        }
    }
}