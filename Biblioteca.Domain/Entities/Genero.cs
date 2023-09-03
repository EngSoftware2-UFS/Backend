using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Genero
{
    public ulong Id { get; set; }

    public string GeneroTextual { get; set; } = null!;

    public string GeneroLiterario { get; set; } = null!;

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
