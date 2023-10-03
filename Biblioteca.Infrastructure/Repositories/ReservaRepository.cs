using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class ReservaRepository : IReservaRepository
    {
        private readonly InfraDbContext _context;

        public ReservaRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> CriarReserva(ulong clienteId)
        {
            var entity = new Reserva();
            entity.CriarReserva(clienteId);
            await _context.Set<Reserva>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task CancelarReserva(Reserva reserva)
        {
            reserva.CancelarReserva();
            _context.Set<Reserva>().Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task FinalizarReserva(Reserva reserva)
        {
            reserva.FinalizarReserva();
            _context.Set<Reserva>().Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReservasView>> GetAll(string? status)
        {
            var results = await _context.ReservasView.FromSqlRaw($@"SELECT r.id, r.dataReserva, r.status, o.Id as obraId, o.titulo, r.clienteId, c.nome as clienteNome
                                                    FROM reservaExemplar re
                                                    JOIN reservas r ON (re.reservaId = r.id)
                                                    JOIN exemplares e ON (re.exemplarId = e.id)
                                                    JOIN obras o ON (o.id = e.obraId)
                                                    JOIN clientes c ON (c.id = r.clienteId)").ToListAsync();

            if (!string.IsNullOrEmpty(status))
                return results.Where(r => r.Status.ToUpper() == status.ToUpper()).ToList();

            return results;
        }

        public async Task<Reserva?> GetById(ulong id)
        {
            return await _context.Set<Reserva>()
                .Include(reserva => reserva.Cliente)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> JaReservado(ulong clienteId, ulong obraId)
        {
            List<int> res = _context.Database.SqlQuery<int>($@"SELECT COUNT(*)
                                                        FROM reservas r JOIN reservaExemplar re ON (r.id = re.reservaId)
                                                        JOIN exemplares ex ON (re.exemplarId = ex.id)
                                                        WHERE r.clienteId = {clienteId} AND ex.obraId = {obraId} AND r.status = 'ATIVA'").ToList();

            var count = res.First();
            return count > 0;
        }

        public async Task<List<ReservaExemplar>> GetExemplares(ulong reservaId)
        {
            return await _context.ReservaExemplar.FromSqlRaw($@"SELECT r.reservaId, r.exemplarId
                                                                FROM reservaExemplar r
                                                                WHERE r.reservaId = {reservaId}").ToListAsync();
        }

        public async Task<List<ReservasView>> GetByClientId(ulong idCliente)
        {
            return await _context.ReservasView.FromSqlRaw($@"SELECT r.id, r.dataReserva, r.status, o.Id as obraId, o.titulo, r.clienteId
                                                    FROM reservaExemplar re
                                                    JOIN reservas r ON (re.reservaId = r.id)
                                                    JOIN exemplares e ON (re.exemplarId = e.id)
                                                    JOIN obras o ON (o.id = e.obraId)
                                                    WHERE r.clienteId = {idCliente}").ToListAsync();
        }

        public async Task<List<ReservasView>> GetByClientName(string nomeCliente)
        {
            return await _context.ReservasView.FromSqlRaw($@"SELECT r.id, r.dataReserva, r.status, o.Id as obraId, o.titulo, r.clienteId, c.nome as clienteNome
                                                    FROM reservaExemplar re
                                                    JOIN reservas r ON (re.reservaId = r.id)
                                                    JOIN exemplares e ON (re.exemplarId = e.id)
                                                    JOIN obras o ON (o.id = e.obraId)
                                                    JOIN clientes c ON (c.id = r.clienteId)
                                                    WHERE c.nome LIKE '%{nomeCliente}%'").ToListAsync();
        }

        public void VerifyReservas()
        {
            _context.Database.ExecuteSqlRaw("CALL `verifica_reservas`");
        }
    }
}
