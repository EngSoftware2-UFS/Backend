﻿// <auto-generated />
using System;
using Biblioteca.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    [DbContext(typeof(InfraDbContext))]
    [Migration("20230820203534_adjustments")]
    partial class adjustments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Biblioteca.Domain.Entities.Atendente", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("EdenrecoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("EnderecoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Atendentes");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Autor", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Bibliotecario", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("EdenrecoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("EnderecoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Bibliotecarios");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Cliente", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Bloqueio")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("EdenrecoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("EnderecoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Editora", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Emprestimo", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("AtendenteId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ClienteId")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("ExemplarId")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("PrazoDevolução")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("QuantidadeRenovacao")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AtendenteId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ExemplarId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Endereco", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Exemplar", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("ObraId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ObraId");

                    b.ToTable("Exemplares");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Genero", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("GeneroLiterario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GeneroTextual")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Multa", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("EmprestimoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Inadimplencia")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("Multas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Obra", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<uint>("Ano")
                        .HasColumnType("int unsigned");

                    b.Property<ulong>("BibliotecarioId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Edicao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<ulong>("EditoraId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecarioId");

                    b.HasIndex("EditoraId");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.ObraAutor", b =>
                {
                    b.Property<ulong>("ObraId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("AutorId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("ObraId", "AutorId");

                    b.ToTable("ObrasAutores");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.ObraGenero", b =>
                {
                    b.Property<ulong>("ObraId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GeneroId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("ObraId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("ObraGeneros");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Reserva", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ClienteId")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("ExemplarId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ExemplarId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Atendente", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Bibliotecario", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Emprestimo", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Atendente", "Atendente")
                        .WithMany("HistoricoEmprestimos")
                        .HasForeignKey("AtendenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Cliente", "Cliente")
                        .WithMany("HistoricoEmprestimos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Exemplar", "Exemplar")
                        .WithMany()
                        .HasForeignKey("ExemplarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendente");

                    b.Navigation("Cliente");

                    b.Navigation("Exemplar");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Exemplar", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Obra", "Obra")
                        .WithMany("Exemplares")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Multa", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Emprestimo", "Emprestimo")
                        .WithMany("Multas")
                        .HasForeignKey("EmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emprestimo");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Obra", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Bibliotecario", "BibliotecarioCadastro")
                        .WithMany("ObrasCadastradas")
                        .HasForeignKey("BibliotecarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Editora", "Editora")
                        .WithMany()
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BibliotecarioCadastro");

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.ObraAutor", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Autor", "Autor")
                        .WithMany("ObraAutores")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Obra", "Obra")
                        .WithMany("ObraAutores")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.ObraGenero", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Genero", "Genero")
                        .WithMany("ObraGeneros")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Obra", "Obra")
                        .WithMany("ObraGeneros")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Cliente", "Cliente")
                        .WithMany("HistoricoReservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Domain.Entities.Exemplar", "Exemplar")
                        .WithMany("HistoricoReservas")
                        .HasForeignKey("ExemplarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Exemplar");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Atendente", b =>
                {
                    b.Navigation("HistoricoEmprestimos");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Autor", b =>
                {
                    b.Navigation("ObraAutores");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Bibliotecario", b =>
                {
                    b.Navigation("ObrasCadastradas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("HistoricoEmprestimos");

                    b.Navigation("HistoricoReservas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Emprestimo", b =>
                {
                    b.Navigation("Multas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Exemplar", b =>
                {
                    b.Navigation("HistoricoReservas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Genero", b =>
                {
                    b.Navigation("ObraGeneros");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Obra", b =>
                {
                    b.Navigation("Exemplares");

                    b.Navigation("ObraAutores");

                    b.Navigation("ObraGeneros");
                });
#pragma warning restore 612, 618
        }
    }
}
