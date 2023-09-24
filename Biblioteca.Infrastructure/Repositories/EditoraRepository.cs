using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class EditoraRepository : IEditoraRepository
    {
        private readonly InfraDbContext _context;

        public EditoraRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<ulong?> Add(Editora entity)
        {
            var result = await _context.Set<Editora>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result?.Entity?.Id;
        }

        public async Task<Editora?> GetByNameAndCountry(string name, string country)
        {
            return await _context.Set<Editora>()
                .Where(e => e.Nome == name && e.Nacionalidade == country).FirstOrDefaultAsync();
        }
    }
}
