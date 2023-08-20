using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Obra
    {
        [Key]
        public ulong Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        public string Idioma { get; set; }
        public uint Ano { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Edicao { get; set; }
        
        public ulong EditoraId { get; set; }
        public virtual Editora? Editora { get; set; }

        [Required]
        public ulong BibliotecarioId { get; set; }
        public virtual Bibliotecario BibliotecarioCadastro { get; set; }
        public virtual ICollection<ObraAutor> ObraAutores { get; set; }
        public virtual ICollection<ObraGenero> ObraGeneros { get; set; }
        public virtual ICollection<Exemplar> Exemplares { get; set; }

    }
}
