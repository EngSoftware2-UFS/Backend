using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using System.Collections.Generic;

namespace Biblioteca.Services
{
    internal class AtendenteService : IAtendenteService
    {
        private readonly IAtendenteRepository _atendenteRepository;
        private readonly IMapper _autoMapper;

        public AtendenteService(IAtendenteRepository atendenteRepository, IMapper autoMapper)
        {
            _atendenteRepository = atendenteRepository;
            _autoMapper = autoMapper;
        }

        public async Task Add(AddAtendenteRequest request)
        {
            Atendente entity = _autoMapper.Map<Atendente>(request);
            await _atendenteRepository.Add(entity);
        }

        public async Task Delete(ulong id)
        {
            await _atendenteRepository.Delete(id);
        }

        public async Task<List<AtendenteResponse>> GetAll()
        {
            List<Atendente> results = await _atendenteRepository.GetAll();
            return _autoMapper.Map<List<AtendenteResponse>>(results);
        }

        public async Task<AtendenteResponse?> GetById(ulong id)
        {
            Atendente? result = await _atendenteRepository.GetById(id);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            return _autoMapper.Map<AtendenteResponse?>(result);
        }

        public async Task<AtendenteResponse?> GetByCpf(string cpf)
        {
            Atendente? result = await _atendenteRepository.GetByCpf(cpf);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            return _autoMapper.Map<AtendenteResponse?>(result);
        }

        public async Task<List<AtendenteResponse>> GetByName(string name)
        {
            List<Atendente> result = await _atendenteRepository.GetByName(name);
            return _autoMapper.Map<List<AtendenteResponse>>(result);
        }

        public void Update(AddAtendenteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}