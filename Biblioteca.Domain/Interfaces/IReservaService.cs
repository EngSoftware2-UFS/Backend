using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;

namespace Biblioteca.Domain.Interfaces
{
    public interface IReservaService
    {
        Task<List<ReservaResponse>> GetReservas(string? status);
        Task<List<ReservaResponse>> GetReservasByClient(string nomeCliente, string? status);
        Task CriarReserva(CriarReservaRequest reserva);
        Task CancelarReserva(CancelarReservaRequest reserva);
        Task FinalizarReserva(ulong reservaId);
    }
}
