using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.Entities;

public partial class Endereco
{
    public int Id { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Complemento { get; set; }
}
