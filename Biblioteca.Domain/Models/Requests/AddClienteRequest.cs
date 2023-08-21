using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddClienteRequest
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public virtual AddEnderecoRequest Endereco { get; private set; }

        public AddClienteRequest(string nome,
            string cpf,
            string email,
            string senha,
            DateTime dataCadastro,
            AddEnderecoRequest endereco)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = senha;
            DataCadastro = dataCadastro;
            Endereco = endereco;
        }
    }
}