using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IAtendenteRepository
    {
        Task Add(Atendente entity);
        Task<List<Atendente>> GetAll();
        Task<Atendente?> GetById(ulong id);
        void Update(Atendente entity);
        Task Delete(ulong id);
    }
}
