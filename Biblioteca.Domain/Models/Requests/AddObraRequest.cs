
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddObraRequest
    {
        public string Titulo { get;  set; }
        public string Idioma { get;  set; }
        public int Ano { get;  set; }
        public string Isbn { get;  set; }
        public string Edicao { get;  set; }
        [Required]
        public ulong EditoraId { get;  set; }
        [Required]
        public ulong GeneroId { get;  set; }
        [Required]
        public ulong BibliotecarioId { get;  set; }


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
