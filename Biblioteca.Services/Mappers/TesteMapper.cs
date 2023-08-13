using AutoMapper;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Services.Mappers
{
    public class TesteMapper : Profile
    {
        public TesteMapper()
        {
            CreateMap<Teste, GetTesteResponse>();
            CreateMap<AddTesteRequest, Teste>();
        }
    }
}
