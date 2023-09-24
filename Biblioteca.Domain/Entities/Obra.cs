using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Entities;

public partial class Obra
{
    public ulong Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Idioma { get; set; } = null!;

    public uint Ano { get; set; }

    public string Isbn { get; set; } = null!;

    public string Edicao { get; set; } = null!;

    public ulong EditoraId { get; set; }
    public ulong GeneroId { get; set; }
    public ulong BibliotecarioId { get; set; }

    public virtual Bibliotecario Bibliotecario { get; set; } = null!;

    public virtual Editora Editora { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Exemplare> Exemplares { get; set; } = new List<Exemplare>();

    public virtual ICollection<Autore> Autors { get; set; } = new List<Autore>();
    public virtual Genero Genero { get; set; } = null!;
}
