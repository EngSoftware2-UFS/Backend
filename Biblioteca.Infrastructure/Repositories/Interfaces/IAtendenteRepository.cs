using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IAtendenteRepository
    {
        Task Add(Atendente entity);
        Task<List<Atendente>> GetAll();
        Task<Atendente?> GetById(ulong id);
        Task<Atendente?> GetByCpf(string cpf);
        Task<List<Atendente>> GetByName(string name);
        Task<Atendente?> GetByEmail(string email);
        Task<Atendente?> GetByEmailOrCpf(string? email, string? cpf);
        Task Update(Atendente entity);
        Task Delete(ulong id);
    }
}
