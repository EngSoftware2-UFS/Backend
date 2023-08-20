using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Autor
    {
        [Key]
        public ulong Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        public ICollection<ObraAutor> ObraAutores { get; set; }

    }
}
