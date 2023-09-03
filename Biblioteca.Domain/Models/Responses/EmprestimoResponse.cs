namespace Biblioteca.Domain.Models.Responses
{
    public class AtendenteEmprestimoResponse
    {
        public ulong Id { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public DateTime PrazoDevolução { get; private set; }
        public int QuantidadeRenovacao { get; private set; }
        public string Status { get; private set; }

        public AtendenteEmprestimoResponse()
        {
        }
    }
}
