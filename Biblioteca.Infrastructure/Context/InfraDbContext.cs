using System;
using System.Collections.Generic;
using System.Data;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Views;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Biblioteca.Infrastructure.Context;

public partial class InfraDbContext : DbContext
{
    public InfraDbContext()
    {
    }

    public InfraDbContext(DbContextOptions<InfraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendente> Atendentes { get; set; }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Bibliotecario> Bibliotecarios { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Editora> Editoras { get; set; }

    public virtual DbSet<Emprestimo> Emprestimos { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Exemplare> Exemplares { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Obra> Obras { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservasView> ReservasView { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservasView>(builder =>
        {
            builder.ToView("ReservasView");
            builder.HasNoKey();
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DataReserva).HasColumnName("dataReserva");
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.Titulo).HasColumnName("titulo");
        });

        modelBuilder.Entity<Atendente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atendentes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf).HasColumnName("CPF");
            entity.Property(e => e.DataCadastro)
                .HasMaxLength(6)
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Senha).HasColumnName("senha");
        });

        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("autores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome).HasColumnName("nome");
        });

        modelBuilder.Entity<Bibliotecario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bibliotecario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf).HasColumnName("CPF");
            entity.Property(e => e.DataCadastro)
                .HasMaxLength(6)
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Senha).HasColumnName("senha");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.EnderecoId, "fk_clientes_endereco1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bloqueio).HasColumnName("bloqueio");
            entity.Property(e => e.Cpf).HasColumnName("CPF");
            entity.Property(e => e.DataCadastro)
                .HasMaxLength(6)
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EnderecoId).HasColumnName("enderecoId");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Senha).HasColumnName("senha");
        });

        modelBuilder.Entity<Editora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("editoras");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nacionalidade).HasColumnName("nacionalidade");
            entity.Property(e => e.Nome).HasColumnName("nome");
        });

        modelBuilder.Entity<Emprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("emprestimos");

            entity.HasIndex(e => e.AtendenteId, "FK_Emprestimos_Atendentes_AtendenteId");

            entity.HasIndex(e => e.ClienteId, "FK_Emprestimos_Clientes_ClienteId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtendenteId).HasColumnName("atendenteId");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.DataDevolucao)
                .HasMaxLength(6)
                .HasColumnName("dataDevolucao");
            entity.Property(e => e.DataEmprestimo)
                .HasMaxLength(6)
                .HasColumnName("dataEmprestimo");
            entity.Property(e => e.Inadimplencia).HasColumnName("inadimplencia");
            entity.Property(e => e.PrazoDevolucao)
                .HasMaxLength(6)
                .HasColumnName("prazoDevolucao");
            entity.Property(e => e.QuantidadeRenovacao).HasColumnName("quantidadeRenovacao");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Atendente).WithMany(p => p.Emprestimos)
                .HasForeignKey(d => d.AtendenteId)
                .HasConstraintName("FK_Emprestimos_Atendentes_AtendenteId");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Emprestimos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Emprestimos_Clientes_ClienteId");

            //entity.HasMany(d => d.Exemplars).WithMany(p => p.Emprestimos)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "EmprestimoExemplar",
            //        r => r.HasOne<Exemplare>().WithMany()
            //            .HasForeignKey("ExemplarId")
            //            .HasConstraintName("fk_emprestimos_has_exemplares_exemplares1"),
            //        l => l.HasOne<Emprestimo>().WithMany()
            //            .HasForeignKey("EmprestimoId")
            //            .HasConstraintName("fk_emprestimos_has_exemplares_emprestimos1"),
            //        j =>
            //        {
            //            j.HasKey("EmprestimoId", "ExemplarId").HasName("PRIMARY");
            //            j.ToTable("emprestimoExemplar");
            //            j.HasIndex(new[] { "ExemplarId" }, "fk_emprestimos_has_exemplares_exemplares1");
            //            j.IndexerProperty<ulong>("EmprestimoId").HasColumnName("emprestimoId");
            //            j.IndexerProperty<ulong>("ExemplarId").HasColumnName("exemplarId");
            //        });
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("endereco");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(200)
                .HasColumnName("bairro");
            entity.Property(e => e.Cidade)
                .HasMaxLength(200)
                .HasColumnName("cidade");
            entity.Property(e => e.Complemento)
                .HasMaxLength(200)
                .HasColumnName("complemento");
            entity.Property(e => e.Logradouro).HasColumnName("logradouro");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
        });

        modelBuilder.Entity<Exemplare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("exemplares");

            entity.HasIndex(e => e.ObraId, "FK_Exemplares_Obras_ObraId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Disponivel).HasColumnName("disponivel");
            entity.Property(e => e.ObraId).HasColumnName("obraId");

            entity.HasOne(d => d.Obra).WithMany(p => p.Exemplares)
                .HasForeignKey(d => d.ObraId)
                .HasConstraintName("FK_Exemplares_Obras_ObraId");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("generos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GeneroLiterario).HasColumnName("generoLiterario");
            entity.Property(e => e.GeneroTextual).HasColumnName("generoTextual");
        });

        modelBuilder.Entity<Obra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("obras");

            entity.HasIndex(e => e.BibliotecarioId, "fk_obras_administradores1");

            entity.HasIndex(e => e.EditoraId, "fk_obras_editoras1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ano).HasColumnName("ano");
            entity.Property(e => e.BibliotecarioId).HasColumnName("bibliotecarioId");
            entity.Property(e => e.Edicao).HasColumnName("edicao");
            entity.Property(e => e.EditoraId).HasColumnName("editoraId");
            entity.Property(e => e.Idioma).HasColumnName("idioma");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Titulo).HasColumnName("titulo");

            entity.HasOne(d => d.Bibliotecario).WithMany(p => p.Obras)
                .HasForeignKey(d => d.BibliotecarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_obras_administradores1");

            entity.HasOne(d => d.Editora).WithMany(p => p.Obras)
                .HasForeignKey(d => d.EditoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_obras_editoras1");

            entity.HasMany(d => d.Autors).WithMany(p => p.Obras)
                .UsingEntity<Dictionary<string, object>>(
                    "Obrasautore",
                    r => r.HasOne<Autore>().WithMany()
                        .HasForeignKey("AutorId")
                        .HasConstraintName("FK_ObrasAutores_Autores_ObraId"),
                    l => l.HasOne<Obra>().WithMany()
                        .HasForeignKey("ObraId")
                        .HasConstraintName("FK_ObrasAutores_Obras_ObraId"),
                    j =>
                    {
                        j.HasKey("ObraId", "AutorId").HasName("PRIMARY");
                        j.ToTable("obrasautores");
                        j.HasIndex(new[] { "AutorId" }, "FK_ObrasAutores_Autores_ObraId");
                        j.IndexerProperty<ulong>("ObraId").HasColumnName("obraId");
                        j.IndexerProperty<ulong>("AutorId").HasColumnName("autorId");
                    });

            entity.HasMany(d => d.Generos).WithMany(p => p.Obras)
                .UsingEntity<Dictionary<string, object>>(
                    "Obragenero",
                    r => r.HasOne<Genero>().WithMany()
                        .HasForeignKey("GeneroId")
                        .HasConstraintName("FK_ObraGeneros_Generos_GeneroId"),
                    l => l.HasOne<Obra>().WithMany()
                        .HasForeignKey("ObraId")
                        .HasConstraintName("FK_ObraGeneros_Obras_ObraId"),
                    j =>
                    {
                        j.HasKey("ObraId", "GeneroId").HasName("PRIMARY");
                        j.ToTable("obrageneros");
                        j.HasIndex(new[] { "GeneroId" }, "FK_ObraGeneros_Generos_GeneroId");
                        j.IndexerProperty<ulong>("ObraId").HasColumnName("obraId");
                        j.IndexerProperty<ulong>("GeneroId").HasColumnName("generoId");
                    });
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.ClienteId, "FK_Reservas_Clientes_ClienteId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.DataReserva)
                .HasMaxLength(6)
                .HasColumnName("dataReserva");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Reservas_Clientes_ClienteId");

            //entity.HasMany(d => d.Exemplars).WithMany(p => p.Reservas)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "ReservaExemplar",
            //        r => r.HasOne<Exemplare>().WithMany()
            //            .HasForeignKey("ExemplarId")
            //            .HasConstraintName("fk_reserva_has_exemplares_exemplares1"),
            //        l => l.HasOne<Reserva>().WithMany()
            //            .HasForeignKey("ReservaId")
            //            .HasConstraintName("fk_reserva_has_exemplares_reserva1"),
            //        j =>
            //        {
            //            j.HasKey("ReservaId", "ExemplarId").HasName("PRIMARY");
            //            j.ToTable("reservaExemplar");
            //            j.HasIndex(new[] { "ExemplarId" }, "fk_reserva_has_exemplares_exemplares1");
            //            j.IndexerProperty<ulong>("ReservaId").HasColumnName("reservaId");
            //            j.IndexerProperty<ulong>("ExemplarId").HasColumnName("exemplarId");
            //        });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
