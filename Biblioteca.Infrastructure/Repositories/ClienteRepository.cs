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

        public async Task<Cliente?> GetByEmail(string email)
        {
            return await _context.Set<Cliente>()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Cliente?> GetByEmailOrCpf(string? email, string? cpf)
        {
            return await _context.Set<Cliente>()
                .FirstOrDefaultAsync(x => x.Email == email || x.Cpf == cpf);
        }

        public async Task Update(Cliente entity)
        {
            _context.Set<Cliente>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Cliente>().SingleAsync(x => x.Id == id);
            _context.Set<Cliente>().Remove(row);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ClienteInadimplente(ulong clientId)
        {
            var rows = await _context.Set<Emprestimo>().Where(ep => ep.Inadimplencia && ep.ClienteId.Equals(clientId)).CountAsync();
            return rows > 0;
        }
    }
}
