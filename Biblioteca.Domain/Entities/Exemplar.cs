using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Exemplar
    {
        [Key]
        public ulong Id { get; set; }
        public bool Disponivel { get; set; }
        public ulong ObraId { get; set; }
        [Required]
        [ForeignKey("ObraId")]
        public virtual Obra Obra { get; set; }

    }
}
