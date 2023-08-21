using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Domain.Interfaces
{
    public interface IClienteService
    {
        Task Add(AddClienteRequest request);
        Task<List<Cliente>> GetAll();
        Task<Cliente?> GetById(ulong id);
        Task<Cliente?> GetByCpf(string cpf);
        Task<List<Cliente>> GetByName(string name);
        Task<List<Reserva>> GetReservas(ulong idCliente);
        Task<List<Reserva>> GetHistoricoReservas(ulong idCliente);
        Task<Reserva?> GetReserva(ulong idCliente, ulong idReserva);
        Task<List<Emprestimo>> GetEmprestimos(ulong idCliente);
        Task<List<Emprestimo>> GetHistoricoEmprestimos(ulong idCliente);
        Task<Emprestimo?> GetEmprestimo(ulong idCliente, ulong idEmprestimo);
        void Update(AddClienteRequest request);
        Task Delete(ulong id);
    }
}
