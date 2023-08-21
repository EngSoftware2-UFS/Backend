using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Bloqueio { get; set; }
        public DateTime DataCadastro { get; set; }
        public ulong EnderecoId { get; set; }
        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }
    }
}
