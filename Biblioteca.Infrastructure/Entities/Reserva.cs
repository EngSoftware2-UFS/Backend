using System;
using System.Collections.Generic;

namespace Biblioteca.Infrastructure.scaffold;

public partial class Reserva
{
    public ulong Id { get; set; }

    public DateTime DataReserva { get; set; }

    public string Status { get; set; } = null!;

    public ulong ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Exemplare> Exemplars { get; set; } = new List<Exemplare>();
}
