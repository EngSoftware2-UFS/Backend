using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddAtendenteRequest
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public virtual Endereco? Endereco { get; private set; }

        public AddAtendenteRequest(string nome,
            string cpf,
            string email,
            string senha,
            DateTime dataCadastro,
            Endereco? endereco)
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