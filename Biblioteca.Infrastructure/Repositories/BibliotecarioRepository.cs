using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class BibliotecarioRepository : IBibliotecarioRepository
    {
        private readonly InfraDbContext _context;

        public BibliotecarioRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Bibliotecario entity)
        {
            await _context.Set<Bibliotecario>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bibliotecario>> GetAll()
        {
            return await _context.Set<Bibliotecario>()
                .Include(bibliotecario => bibliotecario.Endereco)
                .ToListAsync();
        }

        public async Task<Bibliotecario?> GetById(ulong id)
        {
            return await _context.Set<Bibliotecario>()
                .Include(bibliotecario => bibliotecario.Endereco)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Bibliotecario?> GetByCpf(string cpf)
        {
            return await _context.Set<Bibliotecario>()
                .Include(bibliotecario => bibliotecario.Endereco)
                .Where(x => x.CPF == cpf).FirstOrDefaultAsync();
        }

        public async Task<List<Bibliotecario>> GetByName(string name)
        {
            return await _context.Set<Bibliotecario>()
                .Include(bibliotecario => bibliotecario.Endereco)
                .Where(x => x.Nome.Contains(name)).ToListAsync();
        }

        public void Update(Bibliotecario entity)
        {
            _context.Set<Bibliotecario>().Update(entity);
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Bibliotecario>().SingleAsync(x => x.Id == id);
            _context.Set<Bibliotecario>().Remove(row);
            await _context.SaveChangesAsync();
        }
    }
}
