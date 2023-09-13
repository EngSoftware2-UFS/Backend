using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        Task Add(Reserva entity);
        Task<List<Reserva>> GetAll();
        Task<Reserva?> GetById(ulong id);
        Task<List<ReservasView>> GetByClientId(ulong idCliente);
        void Update(Reserva entity);
        Task Delete(ulong id);
    }
}
