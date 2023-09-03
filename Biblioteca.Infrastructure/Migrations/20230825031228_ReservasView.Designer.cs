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
    [Migration("20230825031228_ReservasView")]
    partial class ReservasView
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
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataCadastro")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("atendentes", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Autore", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("autores", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Bibliotecario", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataCadastro")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("bibliotecario", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Cliente", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<bool>("Bloqueio")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("bloqueio");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataCadastro")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int")
                        .HasColumnName("enderecoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EnderecoId" }, "fk_clientes_endereco1");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Editora", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nacionalidade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("editoras", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Emprestimo", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<ulong>("AtendenteId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("atendenteId");

                    b.Property<ulong>("ClienteId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("clienteId");

                    b.Property<DateTime>("DataDevolucao")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataDevolucao");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataEmprestimo");

                    b.Property<bool>("Inadimplencia")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("inadimplencia");

                    b.Property<DateTime>("PrazoDevolucao")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("prazoDevolucao");

                    b.Property<int>("QuantidadeRenovacao")
                        .HasColumnType("int")
                        .HasColumnName("quantidadeRenovacao");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AtendenteId" }, "FK_Emprestimos_Atendentes_AtendenteId");

                    b.HasIndex(new[] { "ClienteId" }, "FK_Emprestimos_Clientes_ClienteId");

                    b.ToTable("emprestimos", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("bairro");

                    b.Property<string>("Cidade")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("cidade");

                    b.Property<string>("Complemento")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("complemento");

                    b.Property<string>("Logradouro")
                        .HasColumnType("longtext")
                        .HasColumnName("logradouro");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("numero");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("endereco", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Exemplare", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("disponivel");

                    b.Property<ulong?>("EmprestimoId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ObraId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("obraId");

                    b.Property<ulong?>("ReservaId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("EmprestimoId");

                    b.HasIndex("ReservaId");

                    b.HasIndex(new[] { "ObraId" }, "FK_Exemplares_Obras_ObraId");

                    b.ToTable("exemplares", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Genero", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<string>("GeneroLiterario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("generoLiterario");

                    b.Property<string>("GeneroTextual")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("generoTextual");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("generos", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Obra", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<uint>("Ano")
                        .HasColumnType("int unsigned")
                        .HasColumnName("ano");

                    b.Property<ulong>("BibliotecarioId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("bibliotecarioId");

                    b.Property<string>("Edicao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("edicao");

                    b.Property<ulong>("EditoraId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("editoraId");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("idioma");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("isbn");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("titulo");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "BibliotecarioId" }, "fk_obras_administradores1");

                    b.HasIndex(new[] { "EditoraId" }, "fk_obras_editoras1");

                    b.ToTable("obras", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Reserva", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    b.Property<ulong>("ClienteId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("clienteId");

                    b.Property<DateTime>("DataReserva")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("dataReserva");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ClienteId" }, "FK_Reservas_Clientes_ClienteId");

                    b.ToTable("reservas", (string)null);
                });

            modelBuilder.Entity("Obragenero", b =>
                {
                    b.Property<ulong>("ObraId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("obraId");

                    b.Property<ulong>("GeneroId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("generoId");

                    b.HasKey("ObraId", "GeneroId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "GeneroId" }, "FK_ObraGeneros_Generos_GeneroId");

                    b.ToTable("obrageneros", (string)null);
                });

            modelBuilder.Entity("Obrasautore", b =>
                {
                    b.Property<ulong>("ObraId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("obraId");

                    b.Property<ulong>("AutorId")
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("autorId");

                    b.HasKey("ObraId", "AutorId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AutorId" }, "FK_ObrasAutores_Autores_ObraId");

                    b.ToTable("obrasautores", (string)null);
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
                        .WithMany("Emprestimos")
                        .HasForeignKey("AtendenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Emprestimos_Atendentes_AtendenteId");

                    b.HasOne("Biblioteca.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Emprestimos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Emprestimos_Clientes_ClienteId");

                    b.Navigation("Atendente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Exemplare", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Emprestimo", null)
                        .WithMany("Exemplars")
                        .HasForeignKey("EmprestimoId");

                    b.HasOne("Biblioteca.Domain.Entities.Obra", "Obra")
                        .WithMany("Exemplares")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Exemplares_Obras_ObraId");

                    b.HasOne("Biblioteca.Domain.Entities.Reserva", null)
                        .WithMany("Exemplars")
                        .HasForeignKey("ReservaId");

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Obra", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Bibliotecario", "Bibliotecario")
                        .WithMany("Obras")
                        .HasForeignKey("BibliotecarioId")
                        .IsRequired()
                        .HasConstraintName("fk_obras_administradores1");

                    b.HasOne("Biblioteca.Domain.Entities.Editora", "Editora")
                        .WithMany("Obras")
                        .HasForeignKey("EditoraId")
                        .IsRequired()
                        .HasConstraintName("fk_obras_editoras1");

                    b.Navigation("Bibliotecario");

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Reservas_Clientes_ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Obragenero", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Genero", null)
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ObraGeneros_Generos_GeneroId");

                    b.HasOne("Biblioteca.Domain.Entities.Obra", null)
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ObraGeneros_Obras_ObraId");
                });

            modelBuilder.Entity("Obrasautore", b =>
                {
                    b.HasOne("Biblioteca.Domain.Entities.Autore", null)
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ObrasAutores_Autores_ObraId");

                    b.HasOne("Biblioteca.Domain.Entities.Obra", null)
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ObrasAutores_Obras_ObraId");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Atendente", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Bibliotecario", b =>
                {
                    b.Navigation("Obras");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Emprestimos");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Editora", b =>
                {
                    b.Navigation("Obras");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Emprestimo", b =>
                {
                    b.Navigation("Exemplars");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Obra", b =>
                {
                    b.Navigation("Exemplares");
                });

            modelBuilder.Entity("Biblioteca.Domain.Entities.Reserva", b =>
                {
                    b.Navigation("Exemplars");
                });
#pragma warning restore 612, 618
        }
    }
}
