using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class AutorRepository : IAutorRepository
    {
        private readonly InfraDbContext _context;

        public AutorRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<ulong?> Add(Autore entity)
        {
            var result = await _context.Set<Autore>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result?.Entity?.Id;
        }

        public async Task<Autore?> GetByName(string name)
        {
            return await _context.Set<Autore>()
                .Where(e => e.Nome == name).FirstOrDefaultAsync();
        }
    }
}
