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
        Task Add(Obra entity);
        Task<IList<Obra>> GetByTitle(string title);
        Task<Obra?> GetById(ulong id);
        Task<IList<Obra>> GetAll();
        void Update(Obra entity);
        Task Delete(ulong id);
    }
}
