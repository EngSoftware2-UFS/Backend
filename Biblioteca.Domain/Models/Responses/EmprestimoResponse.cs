using Biblioteca.Domain.Views;

namespace Biblioteca.Domain.Models.Responses
{
    public class EmprestimoResponse
    {
        public ulong Id { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public DateTime PrazoDevolucao { get; private set; }
        public int QuantidadeRenovacao { get; private set; }
        public bool Inadimplencia { get; private set; }
        public string Status { get; private set; } = "";
        public List<string> Obras { get; private set; } = new List<string>();

        public EmprestimoResponse() { }

        public EmprestimoResponse(
            ulong id,
            DateTime dataEmprestimo,
            DateTime? dataDevolucao,
            DateTime prazoDevolucao,
            int quantidadeRenovacao,
            bool inadimplencia,
            string status)
        {
            Id = id;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            PrazoDevolucao = prazoDevolucao;
            QuantidadeRenovacao = quantidadeRenovacao;
            Inadimplencia = inadimplencia;
            Status = status;
        }

        public EmprestimoResponse(EmprestimosView emprestimoView)
        {
            Id = emprestimoView.Id;
            DataEmprestimo = emprestimoView.DataEmprestimo;
            DataDevolucao = emprestimoView.DataDevolucao;
            PrazoDevolucao = emprestimoView.PrazoDevolucao;
            QuantidadeRenovacao = emprestimoView.QuantidadeRenovacao;
            Inadimplencia = emprestimoView.Inadimplencia;
            Status = emprestimoView.Status;
            addObra(emprestimoView.Titulo);
        }

        public void addObra(string titulo)
        {
            Obras.Add(titulo);
        }
    }
}
