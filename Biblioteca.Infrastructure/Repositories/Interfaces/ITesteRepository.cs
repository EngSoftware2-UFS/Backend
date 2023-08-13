using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface ITesteRepository
    {
        Task Add(Teste entity);
        Task<List<Teste>> GetAll();
        Task<Teste?> GetById(int id);
        void Update(Teste entity);
        Task Delete(int id);
    }
}
