using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IObraRepository
    {
        Task Add(Obra entity, List<ulong> idAutores);
        Task<List<Obra>> GetByTitle(string title);
        Task<List<Obra>> GetByGenero(string genero);
        Task<Obra?> GetById(ulong id);
        Task<List<Obra>> GetAll();
        Task Update(Obra entity, List<ulong> idAutores);
        Task Delete(ulong id);
    }
}
