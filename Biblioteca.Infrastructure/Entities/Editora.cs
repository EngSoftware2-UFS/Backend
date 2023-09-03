﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Infrastructure.scaffold;

public partial class Editora
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Nacionalidade { get; set; } = null!;

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}