using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> CriarEmprestimo(ulong atendenteId, ulong clienteId);
        Task RenovarEmprestimo(Emprestimo emprestimo);
        Task Devolver(Emprestimo emprestimo);
        Task PagarMultaEDevolver(Emprestimo emprestimo);
        Task Cancelar(Emprestimo emprestimo);
        Task<List<EmprestimosView>> GetAll(string? status);
        Task<Emprestimo?> GetById(ulong id);
        Task<List<EmprestimosView>> GetByClientId(ulong idCliente);
        Task<List<EmprestimosView>> GetByClientName(string nomeCliente);
        Task<List<EmprestimoExemplar>> GetExemplares(ulong emprestimoId);
        void VerifyInadimplencia();
    }
}
