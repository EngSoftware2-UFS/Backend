using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task Add(Emprestimo entity);
        Task<List<Emprestimo>> GetAll();
        Task<Emprestimo?> GetById(ulong id);
        Task<List<EmprestimosView>> GetByClientId(ulong idCliente);
        void Update(Emprestimo entity);
        Task Delete(ulong id);
        void VerifyInadimplencia();
    }
}
