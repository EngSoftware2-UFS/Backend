using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Genero
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
    }
}
