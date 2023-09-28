using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Exemplare
{
    public ulong Id { get; set; }

    public bool Disponivel { get; set; } = true;

    public ulong ObraId { get; set; }

    public virtual Obra Obra { get; set; } = null!;
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
