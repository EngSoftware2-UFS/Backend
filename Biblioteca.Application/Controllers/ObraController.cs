using Biblioteca.Application.Filters;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("obras")]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ObraController : ControllerBase
    {

        private readonly IObraService _obraService;
        public ObraController(IObraService obraService)
        {
            _obraService = obraService;
        }

        async Task<IActionResult> Add(AddObraRequest obra)
        {
            await _obraService.Add(obra);
            return Ok();
        }
    }
}
