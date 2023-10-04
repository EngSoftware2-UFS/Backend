using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class ExemplarRepository : IExemplarRepository
    {
        private readonly InfraDbContext _context;

        public ExemplarRepository(InfraDbContext context)
        {
            _context = context;
        }

        public void Add(Exemplare exemplar)
        {
            _context.Database.ExecuteSqlRaw($"INSERT INTO exemplares (disponivel, obraId) VALUES ({exemplar.Disponivel}, {exemplar.ObraId})");
        }

        public async Task<bool> ExemplarDisponivel(ulong obraId)
        {
            var rows = await _context.Set<Exemplare>().CountAsync(ex => ex.ObraId.Equals(obraId) && ex.Disponivel);
            return rows > 0;
        }

        public async Task<Exemplare?> GetExemplarDisponivel(ulong obraId)
        {
            var rows = await _context.Set<Exemplare>().Where(ex => ex.ObraId.Equals(obraId) && ex.Disponivel).ToListAsync();
            return rows.FirstOrDefault();
        }

        public async Task<Exemplare?> GetById(ulong id)
        {
            return await _context.Set<Exemplare>()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AddExemplarToReserva(ulong reservaId, Exemplare exemplar)
        {
            exemplar.CriarReserva();
            _context.Database.ExecuteSqlRaw($"UPDATE exemplares SET disponivel = {exemplar.Disponivel} WHERE id = {exemplar.Id}");
            _context.Database.ExecuteSqlRaw("INSERT INTO reservaExemplar VALUES ({0}, {1})", reservaId, exemplar.Id);
        }

        public void AddExemplarToEmprestimo(ulong reservaId, ulong exemplarId)
        {
            _context.Database.ExecuteSqlRaw("INSERT INTO emprestimoExemplar VALUES ({0}, {1})", reservaId, exemplarId);
        }

        public void RemoveExemplarFromReserva(Exemplare exemplar)
        {
            exemplar.CancelarReserva();
            _context.Database.ExecuteSqlRaw($"UPDATE exemplares SET disponivel = {exemplar.Disponivel} WHERE id = {exemplar.Id}");
        }

        public void DisponibilizarExemplar(ulong exemplarId)
        {
            _context.Database.ExecuteSqlRaw($"UPDATE exemplares SET disponivel = 1 WHERE id = {exemplarId}");
        }
    }
}
