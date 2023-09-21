using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IObraRepository
    {
        Task Add(Obra entity, List<ulong> idAutores);
        Task<List<Obra>> GetByTitle(string title);
        Task<List<Obra>> GetByGenero(ulong idGenero);
        Task<Obra?> GetById(ulong id);
        Task<List<Obra>> GetAll();
        Task Update(Obra entity, List<ulong> idAutores);
        Task Delete(ulong id);
    }
}
