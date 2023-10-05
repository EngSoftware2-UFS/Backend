using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IObraRepository
    {
        Task<Obra> Add(Obra entity, List<ulong> idAutores);
        Task<int> QuantidadeExemplares(ulong obraId);
        Task<List<Obra>> GetByTitle(string title);
        Task<List<Obra>> GetByGenero(string genero);
        Task<List<Obra>> GetByIsbn(string isbn);
        Task<List<Obra>> GetByAuthor(string autor);
        Task<Obra?> GetById(ulong id);
        Task<List<Obra>> GetAll();
        Task Update(Obra entity, List<ulong> idAutores);
        Task Delete(ulong id);
    }
}
