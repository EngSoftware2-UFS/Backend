namespace Biblioteca.Domain.Models.Responses
{
    public class ObraShortResponse
    {
        public ulong Id { get; private set; }
        public string Titulo { get; private set; }

        public ObraShortResponse(ulong id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }
}
