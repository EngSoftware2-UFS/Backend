using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Multa
    {
        [Key]
        public ulong Id { get; set; }
        public bool Inadimplencia { get; set; }
        public Double Valor { get; set; }
        public ulong EmprestimoId { get; set; }
        [ForeignKey("EmprestimoId")]
        public virtual Emprestimo Emprestimo { get; set; }
    }
}
