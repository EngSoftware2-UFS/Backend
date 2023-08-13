using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Domain.Interfaces
{
    public interface ITesteService
    {
        Task Add(AddTesteRequest entity);
        Task<List<GetTesteResponse>> GetAll();
        Task<GetTesteResponse?> GetById(int id);
        void Update(AddTesteRequest entity);
        Task Delete(int id);
    }
}
