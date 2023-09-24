using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Domain.Interfaces
{
    public interface IAtendenteService
    {
        Task Add(AddAtendenteRequest request);
        Task<List<AtendenteResponse>> GetAll();
        Task<AtendenteResponse?> GetById(ulong id);
        Task<AtendenteResponse?> GetByCpf(string cpf);
        Task<List<AtendenteResponse>> GetByName(string name);
        Task Update(UpdateAtendenteRequest request);
        Task Delete(ulong id);
    }
}
