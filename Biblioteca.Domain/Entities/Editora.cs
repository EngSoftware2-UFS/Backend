using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Entities;

public partial class Editora
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Nacionalidade { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
