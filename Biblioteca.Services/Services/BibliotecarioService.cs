using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Services.Common;

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
            if (!Validator.IsCpf(request.CPF))
                throw new InvalidOperationException("Cpf inválido.");

            if (!Validator.IsEmail(request.Email))
                throw new InvalidOperationException("E-mail inválido.");

            request.TrimCpf();

            Bibliotecario? bibliotecario = await _bibliotecarioRepository.GetByEmailOrCpf(request.Email, request.CPF);
            if (bibliotecario != null)
                throw new OperationCanceledException("Cpf ou E-mail inválido.");

            Bibliotecario entity = _autoMapper.Map<Bibliotecario>(request);
            await _bibliotecarioRepository.Add(entity);
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

        public async Task Update(UpdateBibliotecarioRequest request)
        {
            Bibliotecario? bibliotecario = await _bibliotecarioRepository.GetById(request.Id);
            if (bibliotecario == null)
                throw new KeyNotFoundException("Not Found.");

            if (!string.IsNullOrEmpty(request.Cpf) && !Validator.IsCpf(request.Cpf))
                throw new InvalidOperationException("Cpf inválido.");

            if (!string.IsNullOrEmpty(request.Email) && !Validator.IsEmail(request.Email))
                throw new InvalidOperationException("E-mail inválido.");

            if (!string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.Cpf))
            {
                Bibliotecario? bibliotecarioEmail = await _bibliotecarioRepository.GetByEmailOrCpf(request.Email, request.Cpf);

                if (bibliotecarioEmail != null && bibliotecarioEmail.Id != request.Id)
                    throw new OperationCanceledException("Cpf ou E-mail inválido.");
            }

            if (!string.IsNullOrEmpty(request.Cpf))
                request.TrimCpf();

            bibliotecario.Cpf = request.Cpf ?? bibliotecario.Cpf;
            bibliotecario.Nome = request.Nome ?? bibliotecario.Nome;
            bibliotecario.Email = request.Email ?? bibliotecario.Email;

            await _bibliotecarioRepository.Update(bibliotecario);
        }

        public async Task Delete(ulong id)
        {
            await _bibliotecarioRepository.Delete(id);
        }
    }
}