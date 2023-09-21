using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Models.Requests
{
    public class UpdateObraRequest
    {
        public ulong Id { get; set; }
        public string Titulo { get; set; }
        public string Idioma { get; set; }
        public uint Ano { get; set; }
        public string Isbn { get; set; }
        public string Edicao { get; set; }
        [Required]
        public ulong EditoraId { get; set; }
        [Required]
        public ulong GeneroId { get; set; }
        [Required]
        public ulong BibliotecarioId { get; set; }

        public List<ulong> Autores { get; set; }

    }
}
