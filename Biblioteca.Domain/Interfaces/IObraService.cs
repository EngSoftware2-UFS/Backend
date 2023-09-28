using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;

namespace Biblioteca.Domain.Interfaces
{
    public interface IObraService
    {
        Task Add(AddObraRequest request);
        Task Update(UpdateObraRequest request);
        Task Delete(ulong id);
        Task<List<Obra>> GetByTitle(string title);
        Task<Obra> GetById(ulong id);
        Task<List<Obra>> GetByGenero(string genero);
        Task<List<Obra>> GetByTitleAndGenero(string title, string genero);
        Task<List<Obra>> GetAll();
        Task ReservarObra(AddReservaRequest request);
    }
}
