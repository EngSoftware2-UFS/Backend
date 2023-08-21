using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IBibliotecarioRepository
    {
        Task Add(Bibliotecario entity);
        Task<List<Bibliotecario>> GetAll();
        Task<Bibliotecario?> GetById(ulong id);
        Task<Bibliotecario?> GetByCpf(string cpf);
        Task<List<Bibliotecario>> GetByName(string name);
        void Update(Bibliotecario entity);
        Task Delete(ulong id);
    }
}
