using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Domain.Interfaces
{
    public interface IEmprestimoService
    {
        Task<List<EmprestimoResponse>> GetEmprestimos(string? status);
        Task<List<EmprestimoResponse>> GetEmprestimosByClient(string nomeCliente, string? status);
        Task CriarEmprestimo(CriarEmprestimoRequest emprestimo);
        Task RenovarEmprestimo(ulong emprestimoId);
        Task Devolver(ulong emprestimoId);
        Task PagarMultaEDevolver(ulong emprestimoId);
        Task CancelarEmprestimo(ulong emprestimoId);
    }
}
