using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;
using Biblioteca.Domain.Views;

namespace Biblioteca.Services.Mappers
{
    public class FuncionarioMapper : Profile
    {
        public FuncionarioMapper()
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

            CreateMap<Emprestimo, AtendenteEmprestimoResponse>();
            CreateMap<ReservasView, HistoricoReservas>();
        }
    }
}
