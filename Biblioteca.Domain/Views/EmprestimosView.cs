using Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Views
{
    public class EmprestimosView
    {
        public ulong Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public DateTime PrazoDevolucao { get; set; }
        public int QuantidadeRenovacao { get; set; }
        public bool Inadimplencia { get; set; }
        public string Status { get; set; }
        public ulong ObraId { get; set; }
        public string Titulo { get; set; }
        public ulong ClienteId { get; set; }
        public string ClienteNome { get; set; }
    }
}
