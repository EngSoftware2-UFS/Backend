using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class ObraGenero
    {
        [Key]
        public ulong ObraId { get; set; }
        [ForeignKey("ObraId")]
        public virtual Obra Obra { get; set; }
        [Key]
        public ulong GeneroId { get; set; }
        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }
    }
}
