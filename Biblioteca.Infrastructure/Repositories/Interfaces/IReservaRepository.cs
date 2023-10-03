using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva> CriarReserva(ulong clienteId);
        Task CancelarReserva(Reserva reserva);
        Task FinalizarReserva(Reserva reserva);
        Task<List<ReservasView>> GetAll(string? status);
        Task<Reserva?> GetById(ulong id);
        Task<List<ReservaExemplar>> GetExemplares(ulong reservaId);
        Task<List<ReservasView>> GetByClientId(ulong idCliente);
        Task<List<ReservasView>> GetByClientName(string nomeCliente);
        Task<bool> JaReservado(ulong clienteId, ulong obraId);
        void VerifyReservas();
    }
}
