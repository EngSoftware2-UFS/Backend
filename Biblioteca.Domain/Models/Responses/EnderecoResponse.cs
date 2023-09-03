namespace Biblioteca.Domain.Models.Responses
{
    public class EnderecoResponse
    {
        public ulong Id { get; set; }
        public string? Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string? Complemento { get; private set; }

        public EnderecoResponse()
        {
        }
    }
}
