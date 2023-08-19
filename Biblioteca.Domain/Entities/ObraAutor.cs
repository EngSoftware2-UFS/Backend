using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class ObraAutor
    {
        public ulong AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        public ulong ObraId { get; set; }
        public virtual Obra Obra { get; set; }
    }
}
