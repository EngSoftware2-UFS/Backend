﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Bibliotecario : Usuario
    {
        public virtual ICollection<Obra> ObrasCadastradas { get; set; }
    }
}
