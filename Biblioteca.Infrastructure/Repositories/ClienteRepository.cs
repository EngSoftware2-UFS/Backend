using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class ClienteRepository : IClienteRepository
    {
        private readonly InfraDbContext _context;

        public ClienteRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cliente entity)
        {
            await _context.Set<Cliente>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Set<Cliente>()
                .Include(cliente => cliente.Endereco)
                .ToListAsync();
        }

        public async Task<Cliente?> GetById(ulong id)
        {
            return await _context.Set<Cliente>()
                .Include(cliente => cliente.Endereco)
                .Include(cliente => cliente.Reservas)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cliente?> GetByCpf(string cpf)
        {
            return await _context.Set<Cliente>()
                .Include(cliente => cliente.Endereco)
                .Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetByName(string name)
        {
            return await _context.Set<Cliente>()
                .Include(cliente => cliente.Endereco)
                .Where(x => x.Nome.Contains(name)).ToListAsync();
        }

        public async Task<List<ReservasView>> GetReservas(ulong clientId)
        {
            //FormattableString query = $@"SELECT r.id, r.dataReserva, r.status, o.titulo, a.nome
            //                            FROM reservaExemplar re 
            //                            JOIN reservas r ON (re.reservaId = r.id) 
            //                            JOIN exemplares e ON (re.exemplarId = e.id) 
            //                            JOIN obras o ON (o.id = e.obraId)
            //                            JOIN obrasautores oa ON (o.id = oa.obraId) 
            //                            JOIN autores a ON (a.id = oa.autorId)
            //                            WHERE r.clienteId = {clientId} AND r.id = 2";

            //var result = _context.Database.SqlQuery<HistoricoReservas2>(query);
            return await _context.ReservasView.Where(e => e.ClienteId == clientId).ToListAsync();
        }

        public void Update(Cliente entity)
        {
            _context.Set<Cliente>().Update(entity);
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Cliente>().SingleAsync(x => x.Id == id);
            _context.Set<Cliente>().Remove(row);
            await _context.SaveChangesAsync();
        }
    }
}
