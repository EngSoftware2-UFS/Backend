using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Atendente : Usuario
    {
        public virtual ICollection<Emprestimo> HistoricoEmprestimos { get; set; }
    }
}
