using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Views;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly InfraDbContext _context;

        public EmprestimoRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task Add(Emprestimo entity)
        {
            await _context.Set<Emprestimo>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Emprestimo>> GetAll()
        {
            return await _context.Set<Emprestimo>()
                .Include(emprestimo => emprestimo.Cliente)
                .ToListAsync();
        }

        public async Task<Emprestimo?> GetById(ulong id)
        {
            return await _context.Set<Emprestimo>()
                .Include(emprestimo => emprestimo.Cliente)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Emprestimo entity)
        {
            _context.Set<Emprestimo>().Update(entity);
        }

        public async Task<List<EmprestimosView>> GetByClientId(ulong idCliente)
        {
            return await _context.EmprestimosView.FromSqlRaw($@"SELECT e.id, e.dataEmprestimo, e.dataDevolucao, e.prazoDevolucao, e.quantidadeRenovacao, e.inadimplencia, e.status, o.Id as obraId, o.titulo, e.clienteId
                                                    FROM emprestimoExemplar ee
                                                    JOIN emprestimos e ON (ee.emprestimoId = e.id)
                                                    JOIN exemplares ex ON (ex.id = ee.exemplarId)
                                                    JOIN obras o ON (o.id = ex.obraId)
                                                    WHERE e.clienteId = {idCliente}").ToListAsync();
        }

        public async Task Delete(ulong id)
        {
            var row = await _context.Set<Emprestimo>().SingleAsync(x => x.Id == id);
            _context.Set<Emprestimo>().Remove(row);
            await _context.SaveChangesAsync();
        }

        public void VerifyInadimplencia()
        {
            _context.Database.ExecuteSqlRaw("CALL `verifica_inadimplencia`");
        }
    }
}
