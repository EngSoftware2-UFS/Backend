using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Entities;

public partial class Bibliotecario
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Email { get; set; } = null!;

    [JsonIgnore]
    public string Senha { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
