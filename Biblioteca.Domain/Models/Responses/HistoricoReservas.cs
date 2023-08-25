using Biblioteca.Domain.Enums;

namespace Biblioteca.Domain.Models.Responses
{
    public class HistoricoReservas
    {
        public ulong Id { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; }
        public string Titulo { get; set; }
    }
}
