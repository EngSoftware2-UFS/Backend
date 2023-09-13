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

        public async Task Add(Reserva entity)
        {
            await _context.Set<Reserva>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reserva>> GetAll()
        {
            return await _context.Set<Reserva>()
                .Include(reserva => reserva.Cliente)
                .ToListAsync();
        }

        public async Task<Reserva?> GetById(ulong id)
        {
            return await _context.Set<Reserva>()
                .Include(reserva => reserva.Cliente)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Reserva entity)
        {
            _context.Set<Reserva>().Update(entity);
        }

        public async Task<List<ReservasView>> GetByClientId(ulong idCliente)
        {
            return await _context.ReservasView.FromSqlRaw($@"SELECT r.id, r.dataReserva, r.status, o.titulo, r.clienteId
                                                    FROM reservaExemplar re
                                                    JOIN reservas r ON (re.reservaId = r.id)
                                                    JOIN exemplares e ON (re.exemplarId = e.id)
                                                    JOIN obras o ON (o.id = e.obraId)
                                                    WHERE r.clienteId = {idCliente}").ToListAsync();
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Reserva>().SingleAsync(x => x.Id == id);
            _context.Set<Reserva>().Remove(row);
            await _context.SaveChangesAsync();
        }
    }
}
