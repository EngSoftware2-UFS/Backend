using Biblioteca.Domain.Entities;
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
            addObra(emprestimoView.ObraId, emprestimoView.Titulo);
            if (verificaInadimplencia())
                Multa = calcularMulta();
        }

        public void addObra(ulong obraId, string titulo)
        {
            Obras.Add(new ObraShortResponse(obraId, titulo));
        }

        public void setClienteId(ulong clienteId)
        {
            ClienteId = clienteId;
        }

        public void renovarEmprestimo()
        {
            if (QuantidadeRenovacao > 0)
            {
                QuantidadeRenovacao -= 1;
                DataDevolucao = DataDevolucao.HasValue ? DataDevolucao.Value.AddDays(7) : null;
            }
            else throw new OperationCanceledException("Não é possível fazer mais renovações para esse empréstimo.");
        }

        public double calcularMulta()
        {
            const double valorMultaPorDia = 1.00;
            if (verificaInadimplencia() && DataDevolucao.HasValue)
            {
                var diasUltrapassados = (DataDevolucao.Value - DateTime.UtcNow).TotalDays;
                double multa = diasUltrapassados * valorMultaPorDia;
                return multa;
            }

            return 0;
        }

        private bool verificaInadimplencia()
        {
            if (DataDevolucao.HasValue && DataDevolucao.Value > DateTime.UtcNow)
            {
                if (!Inadimplencia) Inadimplencia = true;
                return true;
            }

            return false;
        }
    }
}
