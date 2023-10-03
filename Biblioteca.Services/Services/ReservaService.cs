using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IExemplarRepository _exemplarRepository;
        private readonly IClienteRepository _clienteRepository;

        public ReservaService(
            IReservaRepository reservaRepository,
            IExemplarRepository exemplarRepository,
            IClienteRepository clienteRepository)
        {
            _reservaRepository = reservaRepository;
            _exemplarRepository = exemplarRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ReservaResponse>> GetReservas(string? status)
        {
            List<ReservasView>? results = await _reservaRepository.GetAll(status);
            return FormatResponse(results);
        }

        public async Task<List<ReservaResponse>> GetReservasByClient(string nomeCliente, string? status)
        {
            List<ReservasView>? results = await _reservaRepository.GetByClientName(nomeCliente);

            if (!string.IsNullOrEmpty(status))
                results = results.Where(r => r.Status.ToUpper() == status.ToUpper()).ToList();

            return FormatResponse(results);
        }

        private List<ReservaResponse> FormatResponse(List<ReservasView>? results)
        {
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

        public async Task CriarReserva(CriarReservaRequest reserva)
        {
            var inadimplente = await _clienteRepository.ClienteInadimplente(reserva.ClientId);

            if (inadimplente)
                throw new InvalidOperationException("Resolva sua inadimplência antes de fazer outra reserva.");

            if (reserva.ObrasId.Count > 3)
                throw new InvalidOperationException("Apenas 3 obras são permitidas por reserva.");

            for (var i = 0; i < reserva.ObrasId.Count; i++)
            {
                var obraId = reserva.ObrasId[i];
                if (reserva.ObrasId.Count(o => o == obraId) > 1)
                    throw new InvalidOperationException("Não é possível reservar mais de um exemplar da mesma obra.");

                var obraReservada = await _reservaRepository.JaReservado(reserva.ClientId, obraId);
                if (obraReservada)
                    throw new InvalidOperationException("Você já possui uma reserva ativa com esta obra.");

                var temExemplarDisponivel = await _exemplarRepository.ExemplarDisponivel(obraId);

                if (!temExemplarDisponivel)
                    throw new InvalidOperationException("Alguma obra da reserva não contém exemplar disponível.");
            }

            Reserva reservaCriada = await _reservaRepository.CriarReserva(reserva.ClientId);
            for (var i = 0; i < reserva.ObrasId.Count; i++)
            {
                var obraId = reserva.ObrasId[i];
                var exemplar = await _exemplarRepository.GetExemplarDisponivel(obraId);

                if (exemplar == null)
                    throw new InvalidOperationException("Alguma obra da reserva não contém exemplar disponível.");

                await _exemplarRepository.AddExemplarToReserva(reservaCriada.Id, exemplar);
            }
        }

        public async Task CancelarReserva(CancelarReservaRequest reserva)
        {
            var reservaExemplares = await _reservaRepository.GetExemplares(reserva.ReservaId);
            var reservaEntity = await _reservaRepository.GetById(reserva.ReservaId);

            if (reservaEntity == null) 
                throw new InvalidOperationException("Reserva não encontrada.");

            for (var i = 0; i < reservaExemplares.Count; i++)
            {
                var exemplarId = reservaExemplares[i].exemplarId;
                var exemplar = await _exemplarRepository.GetById(exemplarId);
                if (exemplar != null)
                {
                    await _exemplarRepository.RemoveExemplarFromReserva(reserva.ReservaId, exemplar);
                }
            }

            await _reservaRepository.CancelarReserva(reservaEntity);
        }

        public async Task FinalizarReserva(CancelarReservaRequest reserva)
        {
            var reservaExemplares = await _reservaRepository.GetExemplares(reserva.ReservaId);
            var reservaEntity = await _reservaRepository.GetById(reserva.ReservaId);

            if (reservaEntity == null)
                throw new InvalidOperationException("Reserva não encontrada.");

            for (var i = 0; i < reservaExemplares.Count; i++)
            {
                var exemplarId = reservaExemplares[i].exemplarId;
                var exemplar = await _exemplarRepository.GetById(exemplarId);
                if (exemplar != null)
                {
                    await _exemplarRepository.RemoveExemplarFromReserva(reserva.ReservaId, exemplar);
                }
            }

            await _reservaRepository.FinalizarReserva(reservaEntity);
        }
    }
}
