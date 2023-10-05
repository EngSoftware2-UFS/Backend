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

    public void MaskCpf(bool hide = false)
    {
        string newCpf = string.Empty;
        for (var i = 0; i < Cpf.Length; i++)
        {
            if (i == 3) newCpf += '.';
            if (i == 6) newCpf += ".";
            if (i == 9) newCpf += "-";

            if (hide && i > 2 && i < 9)
                newCpf += "*";
            else newCpf += Cpf[i];
        }

        Cpf = newCpf;
    }

    public void TrimCpf()
    {
        Cpf = Cpf.Trim();
        Cpf = Cpf.Replace(".", "").Replace("-", "");
    }
}
