﻿using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Context
{
    public class InfraDbContext : DbContext
    {
        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options) { }

        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Bibliotecario> Bibliotecarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Exemplar> Exemplares { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<ObraAutor> ObrasAutores { get; set; }
        public DbSet<ObraGenero> ObraGeneros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObraAutor>()
                .HasKey(x => new { x.ObraId, x.AutorId });

            modelBuilder.Entity<ObraAutor>()
                .HasOne(x => x.Obra)
                .WithMany(x => x.ObraAutores)
                .HasForeignKey(x => x.ObraId);

            modelBuilder.Entity<ObraAutor>()
                .HasOne(x => x.Autor)
                .WithMany(x => x.ObraAutores)
                .HasForeignKey(x => x.ObraId);


            modelBuilder.Entity<ObraGenero>()
                .HasKey(x => new { x.ObraId, x.GeneroId });

            modelBuilder.Entity<ObraGenero>()
                .HasOne(x => x.Obra)
                .WithMany(x => x.ObraGeneros)
                .HasForeignKey(x => x.ObraId);

            modelBuilder.Entity<ObraGenero>()
                .HasOne(x => x.Genero)
                .WithMany(x => x.ObraGeneros)
                .HasForeignKey(x => x.GeneroId);

            modelBuilder.Entity<Reserva>()
                .HasOne(x => x.Cliente)
                .WithMany(x => x.HistoricoReservas)
                .HasForeignKey(x => x.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasOne(x => x.Exemplar)
                .WithMany(x => x.HistoricoReservas)
                .HasForeignKey(x => x.ExemplarId);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(x => x.Cliente)
                .WithMany(x => x.HistoricoEmprestimos)
                .HasForeignKey(x => x.ClienteId);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(x => x.Atendente)
                .WithMany(x => x.HistoricoEmprestimos)
                .HasForeignKey(x => x.AtendenteId);

            modelBuilder.Entity<Obra>()
                .HasOne(x => x.BibliotecarioCadastro)
                .WithMany(x => x.ObrasCadastradas)
                .HasForeignKey(x => x.BibliotecarioId);

            base.OnModelCreating(modelBuilder);

        }
    }
}