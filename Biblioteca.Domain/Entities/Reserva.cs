using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }

        public ulong ExemplarId { get; set; }
        [ForeignKey("ExemplarId")]
        public virtual Exemplar Exemplar { get; set; }
    }
}
