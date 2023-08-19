using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Emprestimo
    {
        public ulong Id { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime PrazoDevolução { get; set; }
        public int QuantidadeRenovacao { get; set; }
        public string Status { get; set; }

        public ulong ExemplarId { get; set; }
        public virtual Exemplar Exemplar { get; set; }

        public ulong AtendenteId { get; set; }
        public virtual Atendente Atendente { get; set; }

        public ulong ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
