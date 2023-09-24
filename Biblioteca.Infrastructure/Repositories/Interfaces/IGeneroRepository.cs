using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task<ulong?> Add(Genero entity);
        Task<Genero?> GetByName(string name);
    }
}
