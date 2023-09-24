﻿using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Infrastructure.Repositories.Interfaces;

namespace Biblioteca.Services.Services
{
    public class ObraService : IObraService
    {
        private readonly IMapper _autoMapper;
        private readonly IObraRepository _obraRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IEditoraRepository _editoraRepository;

        public ObraService(IMapper autoMapper,
            IObraRepository obraRepository,
            IAutorRepository autorRepository,
            IGeneroRepository generoRepository,
            IEditoraRepository editoraRepository)
        {
            _autoMapper = autoMapper;
            _obraRepository = obraRepository;
            _autorRepository = autorRepository;
            _generoRepository = generoRepository;
            _editoraRepository = editoraRepository;
        }

        public async Task Add(AddObraRequest request)
        {
            Genero? genero = await _generoRepository.GetByName(request.GeneroNome);
            if (genero == null)
            {
                var newGeneroId = await _generoRepository.Add(new Genero() { Nome = request.GeneroNome });
                request.GeneroId = newGeneroId ?? 0;
            }
            else request.GeneroId = genero.Id;

            for (var i = 0; i < request.Autores.Count; i++)
            {
                string autorNome = request.Autores[i];
                Autore? autor = await _autorRepository.GetByName(autorNome);
                if (autor == null)
                {
                    var newAutorId = await _autorRepository.Add(new Autore { Nome = autorNome });
                    request.AutoresId.Add(newAutorId ?? 0);
                }
                else request.AutoresId.Add(autor.Id);
            }

            Editora? editora = await _editoraRepository.GetByNameAndCountry(request.EditoraNome, request.EditoraNacionalidade);
            if (editora == null)
            {
                var newEditoraId = await _editoraRepository.Add(new Editora() { Nome = request.EditoraNome, Nacionalidade = request.EditoraNacionalidade });
                request.EditoraId = newEditoraId ?? 0;
            }
            else request.EditoraId = editora.Id;

            Obra obra = _autoMapper.Map<Obra>(request);
            await _obraRepository.Add(obra, request.AutoresId);
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

        public async Task<List<Obra>> GetByGenero(string genero)
        {
            List<Obra> obras = await _obraRepository.GetByGenero(genero);
            return obras;
        }

        public async Task<List<Obra>> GetByTitleAndGenero(string title, string genero)
        {
            List<Obra> byTitle = await _obraRepository.GetByTitle(title);
            return byTitle.Where(o => o.Genero.Nome.ToLower().Equals(genero.ToLower())).ToList();
        }

        //public Task ReservarObra(AddReservaRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task Update(UpdateObraRequest request)
        {
            if ((!string.IsNullOrEmpty(request.EditoraNome) && string.IsNullOrEmpty(request.EditoraNacionalidade))
                || (!string.IsNullOrEmpty(request.EditoraNacionalidade) && string.IsNullOrEmpty(request.EditoraNome)))
                throw new OperationCanceledException("Para atualizar a editora da obra, é preciso informar o nome e nacionalidade.");

            Obra? obra = await _obraRepository.GetById(request.Id);
            if (obra == null)
                throw new KeyNotFoundException("Not Found.");

            //Obra novaObra = _autoMapper.Map<Obra>(request);
            obra.Titulo = request.Titulo ?? obra.Titulo;
            obra.Idioma = request.Idioma ?? obra.Idioma;
            obra.Ano = request.Ano ?? obra.Ano;
            obra.Isbn = request.Isbn ?? obra.Isbn;
            obra.Edicao = request.Edicao ?? obra.Edicao;

            if (!string.IsNullOrEmpty(request.GeneroNome))
            {
                Genero? genero = await _generoRepository.GetByName(request.GeneroNome);
                if (genero == null)
                {
                    var newGeneroId = await _generoRepository.Add(new Genero() { Nome = request.GeneroNome });
                    obra.GeneroId = newGeneroId ?? 0;
                }
                else obra.GeneroId = genero.Id;
            }

            if (request.Autores.Count > 0)
            {
                for (var i = 0; i < request.Autores.Count; i++)
                {
                    string autorNome = request.Autores[i];
                    Autore? autor = await _autorRepository.GetByName(autorNome);
                    if (autor == null)
                    {
                        var newAutorId = await _autorRepository.Add(new Autore { Nome = autorNome });
                        request.AutoresId.Add(newAutorId ?? 0);
                    }
                    else request.AutoresId.Add(autor.Id);
                }
            }
            else request.AutoresId = obra.Autors.Select(x => x.Id).ToList();

            if (!string.IsNullOrEmpty(request.EditoraNome) && !string.IsNullOrEmpty(request.EditoraNacionalidade))
            {
                Editora? editora = await _editoraRepository.GetByNameAndCountry(request.EditoraNome, request.EditoraNacionalidade);
                if (editora == null)
                {
                    var newEditoraId = await _editoraRepository.Add(new Editora() { Nome = request.EditoraNome, Nacionalidade = request.EditoraNacionalidade });
                    obra.EditoraId = newEditoraId ?? 0;
                }
                else obra.EditoraId = editora.Id;
            }

            await _obraRepository.Update(obra, request.AutoresId);
        }
    }
}