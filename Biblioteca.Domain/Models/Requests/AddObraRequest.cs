
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddObraRequest
    {
        public string Titulo { get;  set; }
        public string Idioma { get;  set; }
        public uint Ano { get;  set; }
        public string Isbn { get;  set; }
        public string Edicao { get;  set; }
        [Required]
        public string EditoraNome { get; set; }
        [Required]
        public string EditoraNacionalidade { get; set; }
        [JsonIgnore]
        public ulong EditoraId { get;  set; }
        [Required]
        public string GeneroNome { get;  set; }
        [JsonIgnore]
        public ulong GeneroId { get; set; }
        [JsonIgnore]
        public ulong BibliotecarioId { get;  set; }

        public List<string> Autores { get; set; } = new List<string>();
        [JsonIgnore]
        public List<ulong> AutoresId { get; set; } = new List<ulong>();

        //public AddObraRequest(
        //    string titulo,
        //    string idioma,
        //    int ano,
        //    string isbn,
        //    string edicao,
        //    ulong editora,
        //    ulong genero,
        //    ulong bibliotecarioId)
        //{
        //    Titulo = titulo;
        //    Idioma = idioma;
        //    Ano = ano;
        //    Isbn = isbn;
        //    Edicao = edicao;
        //    EditoraId = editora;
        //    GeneroId = genero;
        //    BibliotecarioId = bibliotecarioId;
        //}
    }
}
