using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;
using Biblioteca.Domain.Models.Responses;

namespace Biblioteca.Domain.Interfaces
{
    public interface IBibliotecarioService
    {
        Task Add(AddBibliotecarioRequest request);
        Task<List<Bibliotecario>> GetAll();
        Task<Bibliotecario?> GetById(ulong id);
        Task<Bibliotecario?> GetByCpf(string cpf);
        Task<List<Bibliotecario>> GetByName(string name);
        Task Update(UpdateBibliotecarioRequest request);
        Task Delete(ulong id);
    }
}
