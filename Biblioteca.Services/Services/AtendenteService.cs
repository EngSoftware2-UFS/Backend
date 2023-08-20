using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Services
{
    internal class AtendenteService : IAtendenteService
    {
        private readonly IAtendenteRepository _testeRepository;
        private readonly IMapper _autoMapper;

        public AtendenteService(IAtendenteRepository testeRepository, IMapper autoMapper)
        {
            _testeRepository = testeRepository;
            _autoMapper = autoMapper;
        }

        public async Task Add(AddAtendenteRequest testeData)
        {
            Atendente entity = _autoMapper.Map<Atendente>(testeData);
            await _testeRepository.Add(entity);
        }

        public Task Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAtendenteResponse>> GetAll()
        {
            List<Atendente> results = await _testeRepository.GetAll();
            return _autoMapper.Map<List<GetAtendenteResponse>>(results);
        }

        public Task<GetAtendenteResponse?> GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        public void Update(AddAtendenteRequest testeData)
        {
            throw new NotImplementedException();
        }
    }
}