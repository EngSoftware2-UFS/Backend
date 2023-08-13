using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class TesteRepository : ITesteRepository
    {
        private readonly InfraDbContext _context;

        public TesteRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Teste entity)
        {
            await _context.Set<Teste>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Teste>> GetAll()
        {
            return await _context.Set<Teste>().ToListAsync();
        }

        public async Task<Teste?> GetById(int id)
        {
            return await _context.Set<Teste>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Teste entity)
        {
            _context.Set<Teste>().Update(entity);
        }

        public async Task Delete(int id)
        {
            var row = await _context.Set<Teste>().SingleAsync(x => x.Id == id);
            _context.Set<Teste>().Remove(row);
            await _context.SaveChangesAsync();
        }
    }
}
