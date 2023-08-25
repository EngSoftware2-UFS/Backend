using System;
using System.Collections.Generic;

namespace Biblioteca.Infrastructure.scaffold;

public partial class Cliente
{
    public ulong Id { get; set; }

    public bool Bloqueio { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public int EnderecoId { get; set; }

    public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    public virtual Endereco Endereco { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
