using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Models.Responses
{
    public class GetBibliotecarioResponse
    {
        public ulong Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public GetBibliotecarioResponse(ulong id,
            string nome,
            string cpf,
            string email,
            DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataCadastro = dataCadastro;
        }
    }
}