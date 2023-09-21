﻿using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Interfaces
{
    public interface IObraService
    {
        Task Add(AddObraRequest request);
        Task Update(UpdateObraRequest request);
        Task Delete(ulong id);
        Task<List<Obra>> GetByTitle(string title);
        Task<Obra> GetById(ulong id);
        Task<List<Obra>> GetByGenero(ulong idGenero);
        Task<List<Obra>> GetAll();

       // Task ReservarObra(AddReservaRequest request);
    }
}
