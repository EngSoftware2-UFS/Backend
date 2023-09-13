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
        Task<List<ReservaResponse>> GetReservas(ulong idCliente);
        Task<List<ReservaResponse>> GetHistoricoReservas(ulong idCliente);
        Task<ReservaResponse?> GetReserva(ulong idCliente, ulong idReserva);
        Task<List<EmprestimoResponse>> GetEmprestimos(ulong idCliente);
        Task<List<EmprestimoResponse>> GetHistoricoEmprestimos(ulong idCliente);
        Task<EmprestimoResponse?> GetEmprestimo(ulong idCliente, ulong idEmprestimo);
        void Update(AddClienteRequest request);
        Task Delete(ulong id);
    }
}
