using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enums;
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
        public List<ObraShortResponse> Obras { get; private set; } = new List<ObraShortResponse>();
        public ulong? ClienteId { get; private set; } = null;
        public string? ClienteNome { get; private set; } = null;
        public double? Multa { get; private set; } = null;

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
            ClienteNome = emprestimoView.ClienteNome;
            addObra(emprestimoView.ObraId, emprestimoView.Titulo);
            if (verificaInadimplencia())
                Multa = calcularMulta();
        }

        public void addObra(ulong obraId, string titulo)
        {
            Obras.Add(new ObraShortResponse(obraId, titulo));
        }

        public double calcularMulta()
        {
            const double valorMultaPorDia = 1.00;
            if (verificaInadimplencia())
            {
                var diasUltrapassados = (DateTime.Today - PrazoDevolucao).TotalDays;
                double multa = diasUltrapassados * valorMultaPorDia;
                return multa;
            }

            return 0;
        }

        private bool verificaInadimplencia()
        {
            if (Status != EStatusEmprestimo.ATIVO.ToString()
                && Status != EStatusEmprestimo.ATRASADO.ToString())
                return false;

            if (Inadimplencia)
                return true;

            if (PrazoDevolucao < DateTime.Now)
            {
                if (!Inadimplencia) Inadimplencia = true;
                return true;
            }

            return false;
        }
    }
}
