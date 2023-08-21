using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Context
{
    public class InfraDbContext : DbContext
    {
        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options) { }

        public DbSet<Atendente> Atendentes { get; set; }
        //public DbSet<Autor> Autores { get; set; }
        //public DbSet<Bibliotecario> Bibliotecarios { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Editora> Editoras { get; set; }
        //public DbSet<Emprestimo> Emprestimos { get; set; }
        //public DbSet<Exemplar> Exemplares { get; set; }
        //public DbSet<Genero> Generos { get; set; }
        //public DbSet<Multa> Multas { get; set; }
        //public DbSet<Obra> Obras { get; set; }
        //public DbSet<ObraAutor> ObraAutores { get; set; }
        //public DbSet<ObraGenero> ObraGeneros { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObraAutor>()
                .HasKey(x => new { x.ObraId, x.AutorId });

            modelBuilder.Entity<ObraGenero>()
                .HasKey(x => new { x.ObraId, x.GeneroId });

            modelBuilder.Entity<ObraGenero>()
                .HasOne(x => x.Genero)
                .WithMany(x => x.ObraGeneros)
                .HasForeignKey(x => x.GeneroId);

            base.OnModelCreating(modelBuilder);

        }
    }
}