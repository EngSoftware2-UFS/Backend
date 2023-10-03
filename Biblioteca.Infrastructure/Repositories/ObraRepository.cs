using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Context;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class ObraRepository : IObraRepository
    {
        private readonly InfraDbContext _context;

        public ObraRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<Obra> Add(Obra entity, List<ulong> idAutores)
        {
            entity.Autors = _context.Set<Autore>().Where(a => idAutores.Contains(a.Id)).ToList();
            
            await _context.Set<Obra>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Obra>()
                .SingleAsync(o => o.Id == id);

            _context.Set<Obra>().Remove(row);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Obra>> GetAll()
        {
            return await _context.Set<Obra>()
                .Include(obra => obra.Autors)
                .Include(obra => obra.Genero)
                .Include(obra => obra.Editora)
                .ToListAsync();
        }

        public async Task<int> QuantidadeExemplares(ulong obraId)
        {
            return await _context.Set<Exemplare>().CountAsync(exemplar => exemplar.ObraId.Equals(obraId));
        }

        public async Task<List<Obra>> GetByTitle(string title)
        {
            return await _context.Set<Obra>()
                .Where(o => o.Titulo.ToLower().Contains(title.ToLower()))
                .Include(obra => obra.Autors)
                .Include(obra => obra.Genero)
                .Include(obra => obra.Editora)
                .ToListAsync();
        }

        public async Task<List<Obra>> GetByGenero(string genero)
        {
            return await _context.Set<Obra>()
                .Where(o => o.Genero.Nome.ToLower().Equals(genero.ToLower()))
                .Include(obra => obra.Autors)
                .Include(obra => obra.Genero)
                .Include(obra => obra.Editora)
                .ToListAsync();
        }

        public async Task<Obra?> GetById(ulong id)
        {
            return await _context.Set<Obra>()
                .Include(obra => obra.Autors)
                .Include(obra => obra.Genero)
                .Include(obra => obra.Editora)
                .SingleOrDefaultAsync(o => o.Id == id );
                
        }

        public async Task Update(Obra entity, List<ulong> idAutores)
        {
            entity.Autors = _context.Set<Autore>().Where(a => idAutores.Contains(a.Id)).ToList();
            _context.Set<Obra>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
