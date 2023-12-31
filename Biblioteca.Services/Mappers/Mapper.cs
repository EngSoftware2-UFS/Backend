﻿using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models;
using Biblioteca.Domain.Enums;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Infrastructure.Context;
using Org.BouncyCastle.Security;

namespace Biblioteca.Services.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Atendente
            CreateMap<Atendente, AtendenteResponse>();
            CreateMap<AddAtendenteRequest, Atendente>();
            // Bibliotecario
            CreateMap<Bibliotecario, GetBibliotecarioResponse>();
            CreateMap<AddBibliotecarioRequest, Bibliotecario>();
            // Cliente
            CreateMap<AddClienteRequest, Cliente>();

            CreateMap<AddEnderecoRequest, Endereco>();
            CreateMap<Endereco, EnderecoResponse>();

            CreateMap<EmprestimosView, EmprestimoResponse>()
                .ConstructUsing(emprestimoView =>
                    new EmprestimoResponse(emprestimoView));
            CreateMap<ReservasView, ReservaResponse>()
                .ConstructUsing(reservaView => 
                    new ReservaResponse(reservaView));

            CreateMap<Atendente, UserData>()
                .ConstructUsing(atendente => 
                    new UserData(atendente.Id, atendente.Nome, atendente.Email, ETipoUsuario.ATENDENTE));

            CreateMap<Cliente, UserData>()
                .ConstructUsing(cliente =>
                    new UserData(cliente.Id, cliente.Nome, cliente.Email, ETipoUsuario.CLIENTE));

            CreateMap<Bibliotecario, UserData>()
                .ConstructUsing(bibliotecario =>
                    new UserData(bibliotecario.Id, bibliotecario.Nome, bibliotecario.Email, ETipoUsuario.BIBLIOTECARIO));


            // Obra
            CreateMap<AddObraRequest, Obra>();
            CreateMap<UpdateObraRequest, Obra>();
        }
    }
}
