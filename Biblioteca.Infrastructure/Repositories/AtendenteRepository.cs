﻿using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class AtendenteRepository : IAtendenteRepository
    {
        private readonly InfraDbContext _context;

        public AtendenteRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Atendente entity)
        {
            await _context.Set<Atendente>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Atendente>> GetAll()
        {
            return await _context.Set<Atendente>()
                .Include(atendente => atendente.Endereco)
                .ToListAsync();
        }

        public async Task<Atendente?> GetById(ulong id)
        {
            return await _context.Set<Atendente>()
                .Include(atendente => atendente.Endereco)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Atendente?> GetByCpf(string cpf)
        {
            return await _context.Set<Atendente>()
                .Include(atendente => atendente.Endereco)
                .Where(x => x.CPF == cpf).FirstOrDefaultAsync();
        }

        public async Task<List<Atendente>> GetByName(string name)
        {
            return await _context.Set<Atendente>()
                .Include(atendente => atendente.Endereco)
                .Where(x => x.Nome.Contains(name)).ToListAsync();
        }

        public void Update(Atendente entity)
        {
            _context.Set<Atendente>().Update(entity);
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Atendente>().SingleAsync(x => x.Id == id);
            _context.Set<Atendente>().Remove(row);
            await _context.SaveChangesAsync();
        }
    }
}