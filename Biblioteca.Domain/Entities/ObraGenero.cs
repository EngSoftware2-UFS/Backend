using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class ObraGenero
    {
        public ulong  Id { get; set; }

        public ulong ObraId { get; set; }
        public virtual Obra Obra { get; set; }

        public ulong GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
