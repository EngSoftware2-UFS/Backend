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
    public class ExemplarRepository : IExemplarRepository
    {
        private readonly InfraDbContext _context;
        public ExemplarRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Exemplare entity)
        {
            await _context.Set<Exemplare>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<List<Exemplare>> GetExemplarByObra(ulong idObra, bool? disponivel)
        {
            IQueryable<Exemplare> query = _context.Set<Exemplare>().Where(e => e.ObraId == idObra);

            if (disponivel.HasValue)
            {
                query = query.Where(e => e.Disponivel == disponivel);
            }

            return await query.ToListAsync();

        }
    }
}
