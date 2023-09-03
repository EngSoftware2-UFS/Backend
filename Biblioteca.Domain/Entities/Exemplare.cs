using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Exemplare
{
    public ulong Id { get; set; }

    public bool Disponivel { get; set; }

    public ulong ObraId { get; set; }

    public virtual Obra Obra { get; set; } = null!;
}
