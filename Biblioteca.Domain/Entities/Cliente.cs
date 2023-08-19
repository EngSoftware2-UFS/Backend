using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Cliente : Usuario
    {
        public bool Bloqueio { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
