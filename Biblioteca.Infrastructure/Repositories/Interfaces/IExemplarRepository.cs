using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IExemplarRepository
    {
        void Add(Exemplare exemplar);
        Task<bool> ExemplarDisponivel(ulong obraId);
        Task<Exemplare?> GetExemplarDisponivel(ulong obraId);
        Task<Exemplare?> GetById(ulong id);
        void AddExemplarToReserva(ulong reservaId, Exemplare exemplar);
        void AddExemplarToEmprestimo(ulong reservaId, ulong exemplarId);
        void RemoveExemplarFromReserva(Exemplare exemplar);
        void DisponibilizarExemplar(ulong exemplarId);
    }
}
