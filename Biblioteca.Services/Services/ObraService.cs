using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Services.Services
{
    public class ObraService : IObraService
    {
        private readonly IMapper _autoMapper;
        private readonly IObraRepository _obraRepository;

        public ObraService(IMapper autoMapper, IObraRepository obraRepository)
        {
            _autoMapper = autoMapper;
            _obraRepository = obraRepository;
        }

        public async Task Add(AddObraRequest obraRequest)
        {
            Obra obra = _autoMapper.Map<Obra>(obraRequest);
            await _obraRepository.Add(obra, obraRequest.Autores);
        }

        public async Task Delete(ulong id)
        {
            await _obraRepository.Delete(id);
        }

        public async Task<List<Obra>> GetAll()
        {
            return await _obraRepository.GetAll();
        }
        
        public async Task<Obra> GetById(ulong id)
        {
            Obra? obra = await _obraRepository.GetById(id);
            if(obra == null) 
                throw new KeyNotFoundException("Not Found.");

            return obra;
        }

        public async Task<List<Obra>> GetByTitle(string title)
        {
            List<Obra> obras = await _obraRepository.GetByTitle(title);
            if (obras == null)
                throw new KeyNotFoundException("Not Found.");

            return obras;
        }

        public async Task<List<Obra>> GetByGenero(ulong idGenero)
        {
            List<Obra> obras = await _obraRepository.GetByGenero(idGenero);
            return obras;
        }

        //public Task ReservarObra(AddReservaRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task Update(UpdateObraRequest request)
        {
            Obra? obra = await _obraRepository.GetById(request.Id);
            if (obra == null)
                throw new KeyNotFoundException("Not Found.");

            //Obra novaObra = _autoMapper.Map<Obra>(request);
            obra.Titulo = request.Titulo;
            obra.Idioma = request.Idioma;
            obra.Ano = request.Ano;
            obra.Isbn = request.Isbn;
            obra.Edicao = request.Edicao;
            obra.EditoraId = request.EditoraId;
            obra.GeneroId = request.GeneroId;
            obra.BibliotecarioId = request.BibliotecarioId;

            await _obraRepository.Update(obra, request.Autores);
        }
    }
}
