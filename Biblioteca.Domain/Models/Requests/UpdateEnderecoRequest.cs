namespace Biblioteca.Domain.Models.Requests
{
    public class UpdateEnderecoRequest
    {
        public string? Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Complemento { get; private set; }

        public UpdateEnderecoRequest(string? logradouro,
            string? numero,
            string bairro,
            string cidade,
            string? complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Complemento = complemento;
        }
    }
}
