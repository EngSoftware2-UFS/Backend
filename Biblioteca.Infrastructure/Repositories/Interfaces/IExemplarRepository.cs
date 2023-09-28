using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories.Interfaces
{
    public interface IExemplarRepository
    {
        Task Add(Exemplare entity);
        Task<List<Exemplare>> GetExemplarByObra(ulong idObra, bool? disponivel);
    }
}
