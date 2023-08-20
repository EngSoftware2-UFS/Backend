using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class ObraGenero
    {
        [Key]
        public ulong ObraId { get; set; }
        public virtual Obra Obra { get; set; }
        [Key]
        public ulong GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
