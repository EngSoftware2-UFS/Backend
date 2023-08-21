using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    internal class BibliotecarioService : IBibliotecarioService
    {
        private readonly IBibliotecarioRepository _bibliotecarioRepository;
        private readonly IMapper _autoMapper;

        public BibliotecarioService(IBibliotecarioRepository bibliotecarioRepository, IMapper autoMapper)
        {
            _bibliotecarioRepository = bibliotecarioRepository;
            _autoMapper = autoMapper;
        }

        public async Task Add(AddBibliotecarioRequest request)
        {
            Bibliotecario entity = _autoMapper.Map<Bibliotecario>(request);
            await _bibliotecarioRepository.Add(entity);
        }

        public async Task Delete(ulong id)
        {
            await _bibliotecarioRepository.Delete(id);
        }

        public async Task<List<Bibliotecario>> GetAll()
        {
            List<Bibliotecario> results = await _bibliotecarioRepository.GetAll();
            return _autoMapper.Map<List<Bibliotecario>>(results);
        }

        public async Task<Bibliotecario?> GetById(ulong id)
        {
            Bibliotecario? result = await _bibliotecarioRepository.GetById(id);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            return _autoMapper.Map<Bibliotecario?>(result);
        }

        public async Task<Bibliotecario?> GetByCpf(string cpf)
        {
            Bibliotecario? result = await _bibliotecarioRepository.GetByCpf(cpf);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            return _autoMapper.Map<Bibliotecario?>(result);
        }

        public async Task<List<Bibliotecario>> GetByName(string name)
        {
            List<Bibliotecario>? result = await _bibliotecarioRepository.GetByName(name);
            return _autoMapper.Map<List<Bibliotecario>>(result);
        }

        public void Update(AddBibliotecarioRequest request)
        {
            throw new NotImplementedException();
        }
    }
}