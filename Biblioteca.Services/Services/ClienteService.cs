using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using System.Collections.Generic;
using Biblioteca.Domain.Enums;
using Biblioteca.Domain.Views;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Biblioteca.Services.Common;

namespace Biblioteca.Services
{
    internal class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IMapper _autoMapper;

        public ClienteService(IClienteRepository clienteRepository,
            IReservaRepository reservaRepository,
            IEmprestimoRepository emprestimoRepository,
            IMapper autoMapper)
        {
            _clienteRepository = clienteRepository;
            _reservaRepository = reservaRepository;
            _emprestimoRepository = emprestimoRepository;
            _autoMapper = autoMapper;
        }

        public async Task Add(AddClienteRequest request)
        {
            if (!Validator.IsCpf(request.CPF))
                throw new InvalidOperationException("Cpf inválido.");

            if (!Validator.IsEmail(request.Email))
                throw new InvalidOperationException("E-mail inválido.");

            request.TrimCpf();

            Cliente? cliente = await _clienteRepository.GetByEmailOrCpf(request.Email, request.CPF);
            if (cliente != null)
                throw new OperationCanceledException("Cpf ou E-mail inválido.");

            Cliente entity = _autoMapper.Map<Cliente>(request);
            await _clienteRepository.Add(entity);
        }

        public async Task<List<Cliente>> GetAll()
        {
            List<Cliente> results = await _clienteRepository.GetAll();
            return _autoMapper.Map<List<Cliente>>(results);
        }

        public async Task<Cliente?> GetById(ulong id)
        {
            Cliente? result = await _clienteRepository.GetById(id);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            return _autoMapper.Map<Cliente?>(result);
        }

        public async Task<Cliente?> GetByCpf(string cpf)
        {
            Cliente? result = await _clienteRepository.GetByCpf(cpf);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            return _autoMapper.Map<Cliente?>(result);
        }

        public async Task<List<Cliente>> GetByName(string name)
        {
            List<Cliente>? result = await _clienteRepository.GetByName(name);
            return _autoMapper.Map<List<Cliente>>(result);
        }


        public async Task<List<ReservaResponse>> GetReservas(ulong idCliente)
        {
            List<ReservasView>? results = await _reservaRepository.GetByClientId(idCliente);
            var filteredResults = results?.Where(r => r.Status == EStatusReserva.ATIVA.ToString()).ToList();
            if (filteredResults == null)
                throw new KeyNotFoundException("Not Found.");

            var reservas = new List<ReservaResponse>();
            filteredResults.ForEach(result =>
            {
                var reserva = reservas.Find(e => e.Id == result.Id);
                if (reserva == null)
                {
                    reservas.Add(new ReservaResponse(result));
                }
                else
                {
                    reserva.addObra(result.ObraId, result.Titulo);
                }
            });

            return reservas;
        }

        public async Task<List<ReservaResponse>> GetHistoricoReservas(ulong idCliente)
        {
            List<ReservasView>? results = await _reservaRepository.GetByClientId(idCliente);
            if (results == null)
                throw new KeyNotFoundException("Not Found.");

            var reservas = new List<ReservaResponse>();
            results.ForEach(result =>
            {
                var reserva = reservas.Find(e => e.Id == result.Id);
                if (reserva == null)
                {
                    reservas.Add(new ReservaResponse(result));
                }
                else
                {
                    reserva.addObra(result.ObraId, result.Titulo);
                }
            });

            return reservas;
        }

        public async Task<ReservaResponse?> GetReserva(ulong idCliente, ulong idReserva)
        {
            List<ReservasView>? results = await _reservaRepository.GetByClientId(idCliente);
            var result = results?.Find(r => r.Id == idReserva);
            if (results == null || result == null)
                throw new KeyNotFoundException("Not Found.");

            var allResults = results.Where(r => r.Id == idReserva).ToList();
            if (allResults.Count > 1)
            {
                ReservaResponse? reserva = null;
                allResults.ForEach(singleResult =>
                {
                    if (reserva == null)
                    {
                        reserva = new ReservaResponse(singleResult);
                    }
                    else
                    {
                        reserva.addObra(singleResult.ObraId, singleResult.Titulo);
                    }
                });

                return reserva;
            }
            else
            {
                return _autoMapper.Map<ReservaResponse?>(result);
            }
        }

        public async Task<List<EmprestimoResponse>> GetEmprestimos(ulong idCliente)
        {
            List<EmprestimosView>? results = await _emprestimoRepository.GetByClientId(idCliente);
            var filteredResults = results.Where(e => e.Status == EStatusEmprestimo.ATIVO.ToString()).ToList();
            if (filteredResults == null)
                throw new KeyNotFoundException("Not Found.");

            var emprestimos = new List<EmprestimoResponse>();
            filteredResults.ForEach(result =>
            {
                var emprestimo = emprestimos.Find(e => e.Id == result.Id);
                if (emprestimo == null)
                {
                    emprestimos.Add(new EmprestimoResponse(result));
                }
                else
                {
                    emprestimo.addObra(result.ObraId, result.Titulo);
                }
            });

            return emprestimos;
        }

        public async Task<List<EmprestimoResponse>> GetHistoricoEmprestimos(ulong idCliente)
        {
            List<EmprestimosView>? results = await _emprestimoRepository.GetByClientId(idCliente);
            if (results == null)
                throw new KeyNotFoundException("Not Found.");

            var emprestimos = new List<EmprestimoResponse>();
            results.ForEach(result =>
            {
                var emprestimo = emprestimos.Find(e => e.Id == result.Id);
                if (emprestimo == null)
                {
                    emprestimos.Add(new EmprestimoResponse(result));
                }
                else
                {
                    emprestimo.addObra(result.ObraId, result.Titulo);
                }
            });

            return emprestimos;
        }
        public async Task<EmprestimoResponse?> GetEmprestimo(ulong idCliente, ulong idEmprestimo)
        {
            List<EmprestimosView>? results = await _emprestimoRepository.GetByClientId(idCliente);
            var result = results?.Find(e => e.Id == idEmprestimo);
            if (results == null || result == null)
                throw new KeyNotFoundException("Not Found.");

            var allResults = results.Where(e => e.Id == idEmprestimo).ToList();
            if (allResults.Count > 1)
            {
                EmprestimoResponse? emprestimo = null;
                allResults.ForEach(singleResult =>
                {
                    if (emprestimo == null)
                    {
                        emprestimo = new EmprestimoResponse(singleResult);
                    }
                    else
                    {
                        emprestimo.addObra(singleResult.ObraId, singleResult.Titulo);
                    }
                });

                return emprestimo;
            }
            else
            {
                return _autoMapper.Map<EmprestimoResponse?>(result);
            }
        }

        public async Task Update(UpdateClienteRequest request)
        {
            Cliente? cliente = await _clienteRepository.GetById(request.Id);
            if (cliente == null)
                throw new KeyNotFoundException("Not Found.");

            if (!string.IsNullOrEmpty(request.Cpf) && !Validator.IsCpf(request.Cpf))
                throw new InvalidOperationException("Cpf inválido.");

            if (!string.IsNullOrEmpty(request.Email) && !Validator.IsEmail(request.Email))
                throw new InvalidOperationException("E-mail inválido.");

            if (!string.IsNullOrEmpty(request.Email) || !string.IsNullOrEmpty(request.Cpf))
            {
                Cliente? clienteEmail = await _clienteRepository.GetByEmailOrCpf(request.Email, request.Cpf);

                if (clienteEmail != null && clienteEmail.Id != request.Id)
                    throw new OperationCanceledException("Cpf ou E-mail inválido.");
            }

            if (!string.IsNullOrEmpty(request.Cpf))
                request.TrimCpf();

            cliente.Cpf = request.Cpf ?? cliente.Cpf;
            cliente.Nome = request.Nome ?? cliente.Nome;
            cliente.Email = request.Email ?? cliente.Email;

            if (request.Endereco != null)
            {
                cliente.Endereco.Cidade = request.Endereco.Cidade ?? cliente.Endereco.Cidade;
                cliente.Endereco.Logradouro = request.Endereco.Logradouro ?? cliente.Endereco.Logradouro;
                cliente.Endereco.Numero = request.Endereco.Numero ?? cliente.Endereco.Numero;
                cliente.Endereco.Bairro = request.Endereco.Bairro ?? cliente.Endereco.Bairro;
                cliente.Endereco.Complemento = request.Endereco.Complemento ?? cliente.Endereco.Complemento;
            }

            await _clienteRepository.Update(cliente);
        }

        public async Task Delete(ulong id)
        {
            await _clienteRepository.Delete(id);
        }

        public async Task<int> GetDevolucoesPendentes(ulong clientId)
        {
            return await _emprestimoRepository.GetDevolucoesPendentes(clientId);
        }
    }
}