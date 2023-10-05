using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Models.Responses
{
    public class AtendenteResponse
    {
        public ulong Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public List<Emprestimo> HistoricoEmprestimos { get; private set; }

        public AtendenteResponse()
        {
        }

        public void MaskCpf(bool hide = false)
        {
            string newCpf = string.Empty;
            for (var i = 0; i < Cpf.Length; i++)
            {
                if (i == 3) newCpf += '.';
                if (i == 6) newCpf += ".";
                if (i == 9) newCpf += "-";

                if (hide && i > 2 && i < 9)
                    newCpf += "*";
                else newCpf += Cpf[i];
            }

            Cpf = newCpf;
        }
    }
}