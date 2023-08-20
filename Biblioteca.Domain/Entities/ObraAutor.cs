using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class ObraAutor
    {
        [Key]
        public ulong AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        [Key]
        public ulong ObraId { get; set; }
        public virtual Obra Obra { get; set; }
    }
}
