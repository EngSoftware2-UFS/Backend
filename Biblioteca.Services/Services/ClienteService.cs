using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using System.Collections.Generic;
using Biblioteca.Domain.Enums;

namespace Biblioteca.Services
{
    internal class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _autoMapper;

        public ClienteService(IClienteRepository clienteRepository,
            IReservaRepository reservaRepository,
            IMapper autoMapper)
        {
            _clienteRepository = clienteRepository;
            _reservaRepository = reservaRepository;
            _autoMapper = autoMapper;
        }

        public async Task Add(AddClienteRequest request)
        {
            Cliente entity = _autoMapper.Map<Cliente>(request);
            await _clienteRepository.Add(entity);
        }

        public async Task Delete(ulong id)
        {
            await _clienteRepository.Delete(id);
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


        public async Task<List<Reserva>> GetReservas(ulong idCliente)
        {
            Cliente? result = await _clienteRepository.GetById(idCliente);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            List<Reserva> reservas = await _reservaRepository.GetByClientId(idCliente);

            return reservas.Where(e => e.Status == EStatusReserva.ATIVA.ToString()).ToList();
        }

        public async Task<List<Reserva>> GetHistoricoReservas(ulong idCliente)
        {
            Cliente? result = await _clienteRepository.GetById(idCliente);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            List<Reserva> reservas = await _reservaRepository.GetByClientId(idCliente);

            return reservas;
        }

        public async Task<Reserva?> GetReserva(ulong idCliente, ulong idReserva)
        {
            Cliente? result = await _clienteRepository.GetById(idCliente);
            if (result == null)
                throw new KeyNotFoundException("Not Found.");

            List<Reserva> reservas = await _reservaRepository.GetByClientId(idCliente);

            return reservas.Find(e => e.Id == idReserva);
        }

        public async Task<List<Emprestimo>> GetEmprestimos(ulong idCliente)
        {
            throw new NotImplementedException();
            //Cliente? result = await _clienteRepository.GetById(idCliente);
            //if (result == null)
            //    throw new KeyNotFoundException("Not Found.");

            //return result.HistoricoEmprestimos.Select(x => new Emprestimo
            //{
            //    Id = x.Id,
            //    DataDevolucao = x.DataDevolucao,
            //    DataEmprestimo = x.DataEmprestimo,
            //    PrazoDevolucao = x.PrazoDevolucao,
            //    QuantidadeRenovacao = x.QuantidadeRenovacao,
            //    Status = x.Status,
            //    Exemplar = x.Exemplar,
            //    ExemplarId = x.ExemplarId,
            //    Atendente = x.Atendente.NoHistory(),
            //    AtendenteId = x.AtendenteId,
            //    Multas = x.Multas.Select(e => new Multa()
            //    {
            //        Id = e.Id,
            //        Inadimplencia = e.Inadimplencia,
            //        Valor = e.Valor
            //    }).ToList()
            //}).Where(e => e.Status == EStatusReserva.ATIVA.ToString()).ToList();
        }

        public async Task<List<Emprestimo>> GetHistoricoEmprestimos(ulong idCliente)
        {
            throw new NotImplementedException();
            //Cliente? result = await _clienteRepository.GetById(idCliente);
            //if (result == null)
            //    throw new KeyNotFoundException("Not Found.");

            //return result.HistoricoEmprestimos.Select(x => new Emprestimo
            //{
            //    Id = x.Id,
            //    DataDevolucao = x.DataDevolucao,
            //    DataEmprestimo = x.DataEmprestimo,
            //    PrazoDevolucao = x.PrazoDevolucao,
            //    QuantidadeRenovacao = x.QuantidadeRenovacao,
            //    Status = x.Status,
            //    Exemplar = x.Exemplar,
            //    ExemplarId = x.ExemplarId,
            //    Atendente = x.Atendente.NoHistory(),
            //    AtendenteId = x.AtendenteId,
            //    Multas = x.Multas.Select(e => new Multa()
            //    {
            //        Id = e.Id,
            //        Inadimplencia = e.Inadimplencia,
            //        Valor = e.Valor
            //    }).ToList()
            //}).ToList();
        }
        public async Task<Emprestimo?> GetEmprestimo(ulong idCliente, ulong idEmprestimo)
        {
            throw new NotImplementedException();
            //Cliente? result = await _clienteRepository.GetById(idCliente);
            //if (result == null)
            //    throw new KeyNotFoundException("Not Found.");

            //return result.HistoricoEmprestimos.Select(x => new Emprestimo
            //{
            //    Id = x.Id,
            //    DataDevolucao = x.DataDevolucao,
            //    DataEmprestimo = x.DataEmprestimo,
            //    PrazoDevolucao = x.PrazoDevolucao,
            //    QuantidadeRenovacao = x.QuantidadeRenovacao,
            //    Status = x.Status,
            //    Exemplar = x.Exemplar,
            //    ExemplarId = x.ExemplarId,
            //    Atendente = x.Atendente.NoHistory(),
            //    AtendenteId = x.AtendenteId,
            //    Multas = x.Multas.Select(e => new Multa()
            //    {
            //        Id = e.Id,
            //        Inadimplencia = e.Inadimplencia,
            //        Valor = e.Valor
            //    }).ToList()
            //}).FirstOrDefault(e => e.Id == idEmprestimo);
        }

        public void Update(AddClienteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}