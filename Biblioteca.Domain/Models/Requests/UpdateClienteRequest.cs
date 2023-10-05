using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests;

public partial class UpdateClienteRequest
{
    [JsonIgnore]
    public ulong Id { get; set; }

    public string? Nome { get; set; } = null!;

    public string? Cpf { get; set; } = null!;

    public string? Email { get; set; } = null!;
    public UpdateEnderecoRequest? Endereco { get; set; }

    public void TrimCpf()
    {
        Cpf = Cpf?.Trim();
        Cpf = Cpf?.Replace(".", "").Replace("-", "");
    }
}
