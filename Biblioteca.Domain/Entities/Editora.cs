using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Editora
    {
        [Key]
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
    }
}
