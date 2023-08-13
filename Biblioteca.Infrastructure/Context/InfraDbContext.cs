using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Context
{
    public class InfraDbContext : DbContext
    {
        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options) { }

        public DbSet<Teste> Testes { get; set; }

    }
}