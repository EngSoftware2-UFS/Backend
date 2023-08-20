using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Services.Mappers
{
    public class FuncionarioMapper : Profile
    {
        public FuncionarioMapper()
        {
            // Atendente
            CreateMap<Atendente, GetAtendenteResponse>();
            CreateMap<AddAtendenteRequest, Atendente>();
            // Bibliotecario
            CreateMap<Bibliotecario, GetBibliotecarioResponse>();
            CreateMap<AddBibliotecarioRequest, Bibliotecario>();
        }
    }
}
