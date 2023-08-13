using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Services
{
    internal class TesteService : ITesteService
    {
        private readonly ITesteRepository _testeRepository;
        private readonly IMapper _autoMapper;

        public TesteService(ITesteRepository testeRepository, IMapper autoMapper)
        {
            _testeRepository = testeRepository;
            _autoMapper = autoMapper;
        }

        public async Task Add(AddTesteRequest testeData)
        {
            Teste entity = _autoMapper.Map<Teste>(testeData);
            await _testeRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetTesteResponse>> GetAll()
        {
            List<Teste> results = await _testeRepository.GetAll();
            return _autoMapper.Map<List<GetTesteResponse>>(results);
        }

        public Task<GetTesteResponse?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AddTesteRequest testeData)
        {
            throw new NotImplementedException();
        }
    }
}