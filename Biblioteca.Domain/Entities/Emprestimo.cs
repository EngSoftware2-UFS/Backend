using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Emprestimo
    {
        [Key]
        public ulong Id { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; } = null;
        public DateTime PrazoDevolucao { get; set; }
        public int QuantidadeRenovacao { get; set; }
        public string Status { get; set; }

        [ForeignKey("ExemplarId")]
        public ulong ExemplarId { get; set; }
        public virtual Exemplar Exemplar { get; set; }

        [ForeignKey("AtendenteId")]
        public ulong AtendenteId { get; set; }
        public virtual Atendente Atendente { get; set; }

        [ForeignKey("ClienteId")]
        public ulong ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Multa> Multas { get; set; }
    }
}
