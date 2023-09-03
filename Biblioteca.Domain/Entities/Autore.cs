using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Autore
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
