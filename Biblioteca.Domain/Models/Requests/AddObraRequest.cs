using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddObraRequest
    {
        public string Titulo { get; private set; }
        public string Idioma { get; private set; }
        public int Ano { get; private set; }
        public string ISBN { get; private set; }
        public string Edicao { get; private set; }
        public ulong Editora { get; private set; }
        public ulong Genero { get; private set; }
        public ulong BibliotecarioId { get; private set; }

        //public List<ulong> Autores { get; private set; }
        public AddObraRequest(
            string titulo,
            string idioma,
            int ano,
            string isbn,
            string edicao,
            ulong editora,
            ulong genero,
            ulong bibliotecarioId
            /*List<ulong> autores*/)
        {
            Titulo = titulo;
            Idioma = idioma;
            Ano = ano;
            ISBN = isbn;
            Edicao = edicao;
            Editora = editora;
            Genero = genero;
            BibliotecarioId = bibliotecarioId;
            //Autores = autores;
        }
    }
}
