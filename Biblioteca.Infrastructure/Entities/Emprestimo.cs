using System;
using System.Collections.Generic;

namespace Biblioteca.Infrastructure.scaffold;

public partial class Emprestimo
{
    public ulong Id { get; set; }

    public DateTime DataEmprestimo { get; set; }

    public DateTime DataDevolucao { get; set; }

    public DateTime PrazoDevolucao { get; set; }

    public int QuantidadeRenovacao { get; set; }

    public string Status { get; set; } = null!;

    public bool Inadimplencia { get; set; }

    public ulong AtendenteId { get; set; }

    public ulong ClienteId { get; set; }

    public virtual Atendente Atendente { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Exemplare> Exemplars { get; set; } = new List<Exemplare>();
}
