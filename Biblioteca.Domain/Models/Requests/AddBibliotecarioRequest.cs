using System.Text.Json.Serialization;
using BC = BCrypt.Net.BCrypt;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddBibliotecarioRequest
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; private set; }

        public AddBibliotecarioRequest(string nome,
            string cpf,
            string email,
            string senha)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = BC.HashPassword(senha, BC.GenerateSalt(10));
            DataCadastro = DateTime.UtcNow;
        }

        public void TrimCpf()
        {
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
        }
    }
}