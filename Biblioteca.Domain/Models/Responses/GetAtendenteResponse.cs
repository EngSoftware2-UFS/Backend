﻿using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Models.Responses
{
    public class GetAtendenteResponse
    {
        public ulong Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ulong EdenrecoId { get; private set; }
        public virtual Endereco? Endereco { get; private set; }

        public GetAtendenteResponse(ulong id,
            string nome,
            string cpf,
            string email,
            DateTime dataCadastro,
            ulong edenrecoId,
            Endereco? endereco)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataCadastro = dataCadastro;
            EdenrecoId = edenrecoId;
            Endereco = endereco;
        }
    }
}