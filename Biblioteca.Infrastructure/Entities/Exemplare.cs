using System;
using System.Collections.Generic;

namespace Biblioteca.Infrastructure.scaffold;

public partial class Exemplare
{
    public ulong Id { get; set; }

    public bool Disponivel { get; set; }

    public ulong ObraId { get; set; }

    public virtual Obra Obra { get; set; } = null!;

    public virtual ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
