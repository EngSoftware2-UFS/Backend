﻿using System.Text.Json.Serialization;
using BC = BCrypt.Net.BCrypt;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddClienteRequest
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; private set; }
        public virtual AddEnderecoRequest Endereco { get; private set; }

        public AddClienteRequest(string nome,
            string cpf,
            string email,
            string senha,
            AddEnderecoRequest endereco)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = BC.HashPassword(senha, BC.GenerateSalt(10));
            DataCadastro = DateTime.UtcNow;
            Endereco = endereco;
        }

        public void TrimCpf()
        {
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
        }
    }
}