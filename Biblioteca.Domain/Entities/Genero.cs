using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Genero
    {
        [Key]
        public ulong Id { get; set; }
        public string GeneroTextual { get; set; }
        public string GeneroLiterario { get; set; }
        public virtual ICollection<ObraGenero> ObraGeneros { get; set; }

    }
}
