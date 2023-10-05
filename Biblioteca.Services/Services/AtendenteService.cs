using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Services.Common;

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
            if (!Validator.IsCpf(request.CPF))
                throw new InvalidOperationException("Cpf inválido.");

            if (!Validator.IsEmail(request.Email))
                throw new InvalidOperationException("E-mail inválido.");

            request.TrimCpf();

            Atendente? atendente = await _atendenteRepository.GetByEmailOrCpf(request.Email, request.CPF);
            if (atendente != null)
                throw new OperationCanceledException("Cpf ou E-mail inválido.");

            Atendente entity = _autoMapper.Map<Atendente>(request);
            await _atendenteRepository.Add(entity);
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

        public async Task Update(UpdateAtendenteRequest request)
        {
            Atendente? atendente = await _atendenteRepository.GetById(request.Id);
            if (atendente == null)
                throw new KeyNotFoundException("Not Found.");

            if (!string.IsNullOrEmpty(request.Cpf) && !Validator.IsCpf(request.Cpf))
                throw new InvalidOperationException("Cpf inválido.");

            if (!string.IsNullOrEmpty(request.Email) && !Validator.IsEmail(request.Email))
                throw new InvalidOperationException("E-mail inválido.");

            if (!string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.Cpf))
            {
                Atendente? atendenteEmail = await _atendenteRepository.GetByEmailOrCpf(request.Email, request.Cpf);

                if (atendenteEmail != null && atendenteEmail.Id != request.Id)
                    throw new OperationCanceledException("Cpf ou E-mail inválido.");
            }

            if (!string.IsNullOrEmpty(request.Cpf))
                request.TrimCpf();

            atendente.Cpf = request.Cpf ?? atendente.Cpf;
            atendente.Nome = request.Nome ?? atendente.Nome;
            atendente.Email = request.Email ?? atendente.Email;

            await _atendenteRepository.Update(atendente);
        }

        public async Task Delete(ulong id)
        {
            await _atendenteRepository.Delete(id);
        }
    }
}