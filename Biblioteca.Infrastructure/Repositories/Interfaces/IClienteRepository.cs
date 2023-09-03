using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task Add(Cliente entity);
        Task<List<Cliente>> GetAll();
        Task<Cliente?> GetById(ulong id);
        Task<Cliente?> GetByCpf(string cpf);
        Task<List<Cliente>> GetByName(string name);
        Task<Cliente?> GetByEmail(string email);
        Task<List<ReservasView>> GetReservas(ulong clienteId);
        void Update(Cliente entity);
        Task Delete(ulong id);
    }
}
