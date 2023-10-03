using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IExemplarRepository
    {
        Task Add(Exemplare exemplar);
        Task<bool> ExemplarDisponivel(ulong obraId);
        Task<Exemplare?> GetExemplarDisponivel(ulong obraId);
        Task<Exemplare?> GetById(ulong id);
        Task AddExemplarToReserva(ulong reservaId, Exemplare exemplar);
        Task RemoveExemplarFromReserva(ulong reservaId, Exemplare exemplar);
    }
}
