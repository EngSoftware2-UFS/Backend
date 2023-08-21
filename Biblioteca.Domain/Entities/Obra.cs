using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //public uint Exemplares { get; set; }
        
        public ulong EditoraId { get; set; }
        [ForeignKey("EditoraId")]
        public virtual Editora? Editora { get; set; }

        [Required]
        [ForeignKey("BibliotecarioCadastroId")]
        public virtual Bibliotecario BibliotecarioCadastro { get; set; }

    }
}
