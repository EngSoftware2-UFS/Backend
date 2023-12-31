﻿using Biblioteca.Application.Filters;
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
    public class ObraController : ControllerBase
    {

        private readonly IObraService _obraService;
        private readonly ILoginService _loginService;

        public ObraController(IObraService obraService, ILoginService loginService)
        {
            _obraService = obraService;
            _loginService = loginService;
        }
        [HttpPost]
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Add(AddObraRequest obra)
        {
            if (obra == null)
                return BadRequest();

            var loggedUser = _loginService.GetAuthenticatedUserById(User.Identity?.Name);
            if (loggedUser == null)
                return Unauthorized("Usuário cadastrante não encontrado!");

            obra.BibliotecarioId = loggedUser.Id;

            await _obraService.Add(obra);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? title, string? genero, string? isbn, string? autor)
        {
            List<Obra> obras;

            if (!string.IsNullOrEmpty(title)) 
            { 
                obras = await _obraService.GetByTitle(title);   
            }
            else if(!string.IsNullOrEmpty(genero))
            {
                obras = await _obraService.GetByGenero(genero);  
            }
            else if (!string.IsNullOrEmpty(isbn))
            {
                obras = await _obraService.GetByIsbn(isbn);
            }
            else if (!string.IsNullOrEmpty(autor))
            {
                obras = await _obraService.GetByAuthor(autor);
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
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Delete(ulong idObra)
        {
            await _obraService.Delete(idObra);
            return Ok();
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "BIBLIOTECARIO")]
        public async Task<IActionResult> Update(ulong id, [FromBody] UpdateObraRequest obra)
        {
            if (obra == null)
                return BadRequest();

            obra.Id = id;
            await _obraService.Update(obra);
            return Ok();
        }


    }
}
