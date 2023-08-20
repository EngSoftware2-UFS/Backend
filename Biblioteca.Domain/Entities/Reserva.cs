using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Reserva
    {
        [Key]
        public ulong Id { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; }

        public ulong ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public ulong ExemplarId { get; set; }
        public virtual Exemplar Exemplar { get; set; }
    }
}
