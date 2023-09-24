using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IEditoraRepository
    {
        Task<ulong?> Add(Editora entity);
        Task<Editora?> GetByNameAndCountry(string name, string country);
    }
}
