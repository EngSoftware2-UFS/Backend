using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Context;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories
{
    public class ObraRepository : IObraRepository
    {
        private readonly InfraDbContext _context;

        public ObraRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Obra entity)
        {
            await _context.Set<Obra>().AddAsync(entity);
            await _context.SaveChangesAsync();
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
                .ToListAsync();
        }

        public async Task<List<Obra>> GetByTitle(string title)
        {
            return await _context.Set<Obra>()
                .Where(o => o.Titulo.Equals(title))
                .Include(obra => obra.Autors)
                .Include(obra => obra.Genero)
                .ToListAsync();
        }

        public async Task<List<Obra>> GetByGenero(ulong idGenero)
        {
            return await _context.Set<Obra>()
                .Where(o => o.GeneroId == idGenero)
                .Include(obra => obra.Autors)
                .ToListAsync();
        }

        public async Task<Obra?> GetById(ulong id)
        {
            return await _context.Set<Obra>()
                .SingleOrDefaultAsync(o => o.Id == id );
                
        }

        public void Update(Obra entity)
        {
            _context.Set<Obra>().Update(entity);
        }
    }
}
