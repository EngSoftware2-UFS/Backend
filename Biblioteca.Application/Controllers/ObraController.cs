using Biblioteca.Application.Filters;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("obras")]
    [TypeFilter(typeof(ExceptionFilter))]
    //[Authorize]
    public class ObraController : ControllerBase
    {

        private readonly IObraService _obraService;
        public ObraController(IObraService obraService)
        {
            _obraService = obraService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddObraRequest obra)
        {
            await _obraService.Add(obra);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? title, ulong? genero)
        {
            List<Obra> obras;

            if (!string.IsNullOrEmpty(title)) 
            { 
                obras = await _obraService.GetByTitle(title);   
            }
            else if(genero != null)
            {
                obras = await _obraService.GetByGenero(genero.Value);  
            }
            else 
            {
                obras = await _obraService.GetAll(); 
            }

            return Ok(obras);

        }
        [HttpGet("{idObra}")]
        public async Task<IActionResult> GetById(ulong idObra)
        {
            Obra obra = await _obraService.GetById(idObra);
            return Ok(obra);
        }
        [HttpDelete("{idObra}")]
        public async Task<IActionResult> Delete(ulong idObra)
        {
            await _obraService.Delete(idObra);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(AddObraRequest obra)
        {
             _obraService.Update(obra);
            return Ok();
        }


    }
}
