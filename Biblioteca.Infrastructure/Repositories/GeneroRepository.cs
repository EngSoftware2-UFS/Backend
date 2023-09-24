using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class GeneroRepository : IGeneroRepository
    {
        private readonly InfraDbContext _context;

        public GeneroRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<ulong?> Add(Genero entity)
        {
            var result = await _context.Set<Genero>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result?.Entity?.Id;
        }

        public async Task<Genero?> GetByName(string name)
        {
            return await _context.Set<Genero>()
                .Where(e => e.Nome.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }
    }
}
