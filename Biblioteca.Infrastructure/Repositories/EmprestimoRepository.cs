using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Repositories.Interfaces;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Views;
using Biblioteca.Domain.Enums;

namespace Biblioteca.Infrastructure.Repositories
{
    internal class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly InfraDbContext _context;

        public EmprestimoRepository(InfraDbContext context)
        {
            _context = context;
        }

        public async Task<Emprestimo> CriarEmprestimo(ulong atendenteId, ulong clienteId)
        {
            var entity = new Emprestimo();
            entity.CriarEmprestimo(atendenteId, clienteId);
            await _context.Set<Emprestimo>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task RenovarEmprestimo(Emprestimo emprestimo)
        {
            _context.Set<Emprestimo>().Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task Devolver(Emprestimo emprestimo)
        {
            emprestimo.Devolver();
            _context.Set<Emprestimo>().Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task PagarMultaEDevolver(Emprestimo emprestimo)
        {
            emprestimo.PagarMultaEDevolver();
            _context.Set<Emprestimo>().Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task Cancelar(Emprestimo emprestimo)
        {
            emprestimo.CancelarEmprestimo();
            _context.Set<Emprestimo>().Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmprestimosView>> GetAll(string? status)
        {
            var results = await _context.EmprestimosView.FromSqlRaw($@"SELECT e.id, e.dataEmprestimo, e.dataDevolucao, e.prazoDevolucao, e.quantidadeRenovacao, e.inadimplencia, e.status, o.Id as obraId, o.titulo, e.clienteId, c.nome as clienteNome
                                                    FROM emprestimoExemplar ee
                                                    JOIN emprestimos e ON (ee.emprestimoId = e.id)
                                                    JOIN exemplares ex ON (ex.id = ee.exemplarId)
                                                    JOIN obras o ON (o.id = ex.obraId)
                                                    JOIN clientes c ON (c.id = e.clienteId)").ToListAsync();

            if (!string.IsNullOrEmpty(status))
                results = results.Where(e => e.Status.Equals(status)).ToList();

            return results;
        }

        public async Task<Emprestimo?> GetById(ulong id)
        {
            return await _context.Set<Emprestimo>()
                .Include(emprestimo => emprestimo.Cliente)
                .Include(emprestimo => emprestimo.Atendente)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<EmprestimosView>> GetByClientId(ulong idCliente)
        {
            return await _context.EmprestimosView.FromSqlRaw($@"SELECT e.id, e.dataEmprestimo, e.dataDevolucao, e.prazoDevolucao, e.quantidadeRenovacao, e.inadimplencia, e.status, o.Id as obraId, o.titulo, e.clienteId, c.nome as clienteNome
                                                    FROM emprestimoExemplar ee
                                                    JOIN emprestimos e ON (ee.emprestimoId = e.id)
                                                    JOIN exemplares ex ON (ex.id = ee.exemplarId)
                                                    JOIN obras o ON (o.id = ex.obraId)
                                                    JOIN clientes c ON (c.id = e.clienteId)
                                                    WHERE e.clienteId = {idCliente}").ToListAsync();
        }

        public async Task<List<EmprestimosView>> GetByClientName(string nomeCliente)
        {
            return await _context.EmprestimosView.FromSqlRaw($@"SELECT e.id, e.dataEmprestimo, e.dataDevolucao, e.prazoDevolucao, e.quantidadeRenovacao, e.inadimplencia, e.status, o.Id as obraId, o.titulo, e.clienteId, c.nome as clienteNome
                                                    FROM emprestimoExemplar ee
                                                    JOIN emprestimos e ON (ee.emprestimoId = e.id)
                                                    JOIN exemplares ex ON (ex.id = ee.exemplarId)
                                                    JOIN obras o ON (o.id = ex.obraId)
                                                    JOIN clientes c ON (c.id = e.clienteId)
                                                    WHERE c.nome LIKE '%{nomeCliente}%'").ToListAsync();
        }

        public async Task<int> GetDevolucoesPendentes(ulong clientId)
        {
            return await _context.Emprestimos.CountAsync(x => x.ClienteId.Equals(clientId) 
            && (x.Status == EStatusEmprestimo.ATIVO.ToString() || x.Status == EStatusEmprestimo.ATRASADO.ToString()));
        }

        public async Task<List<EmprestimoExemplar>> GetExemplares(ulong emprestimoId)
        {
            return await _context.EmprestimoExemplar.FromSqlRaw($@"SELECT e.emprestimoId, e.exemplarId
                                                                FROM emprestimoExemplar e
                                                                WHERE e.emprestimoId = {emprestimoId}").ToListAsync();
        }

        public void VerifyInadimplencia()
        {
            _context.Database.ExecuteSqlRaw("CALL `verifica_inadimplencia`");
        }
    }
}
