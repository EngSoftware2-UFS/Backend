using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests
{
    public class UpdateObraRequest
    {
        [JsonIgnore]
        public ulong Id { get; set; }
        public string? Titulo { get; set; }
        public string? Idioma { get; set; }
        public uint? Ano { get; set; }
        public string? Isbn { get; set; }
        public string? Edicao { get; set; }
        public string? EditoraNome { get; set; }
        public string? EditoraNacionalidade { get; set; }
        [JsonIgnore]
        public ulong EditoraId { get; set; }
        public string? GeneroNome { get; set; }
        [JsonIgnore]
        public ulong GeneroId { get; set; }

        public List<string> Autores { get; set; } = new List<string>();
        [JsonIgnore]
        public List<ulong> AutoresId { get; set; } = new List<ulong>();

    }
}
