using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Domain.Interfaces
{
    public interface IAtendenteService
    {
        Task Add(AddAtendenteRequest testeData);
        Task<List<GetAtendenteResponse>> GetAll();
        Task<GetAtendenteResponse?> GetById(ulong id);
        void Update(AddAtendenteRequest testeData);
        Task Delete(ulong id);
    }
}
