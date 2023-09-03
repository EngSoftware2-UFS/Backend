using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Models.Responses
{
    public class AtendenteResponse
    {
        public ulong Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public List<Emprestimo> HistoricoEmprestimos { get; private set; }

        public AtendenteResponse()
        {
        }
    }
}