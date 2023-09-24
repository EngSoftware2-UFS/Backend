using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests;

public partial class UpdateAtendenteRequest
{
    [JsonIgnore]
    public ulong Id { get; set; }

    public string? Nome { get; set; } = null!;

    public string? Cpf { get; set; } = null!;

    public string? Email { get; set; } = null!;
}
