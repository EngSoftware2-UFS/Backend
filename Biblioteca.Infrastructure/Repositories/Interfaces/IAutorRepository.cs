using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IAutorRepository
    {
        Task<ulong?> Add(Autore entity);
        Task<Autore?> GetByName(string name);
    }
}
