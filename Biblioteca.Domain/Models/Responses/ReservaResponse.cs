using Biblioteca.Domain.Views;

namespace Biblioteca.Domain.Models.Responses
{
    public class ReservaResponse
    {
        public ulong Id { get; private set; }
        public DateTime DataReserva { get; private set; }
        public string Status { get; private set; } = "";
        public List<string> Obras { get; private set; } = new List<string>();

        public ReservaResponse() { }

        public ReservaResponse(ulong id, DateTime dataReserva, string status)
        {
            Id = id;
            DataReserva = dataReserva;
            Status = status;
        }

        public ReservaResponse(ReservasView reservaView)
        {
            Id = reservaView.Id;
            DataReserva = reservaView.DataReserva;
            Status = reservaView.Status;
            addObra(reservaView.Titulo);
        }

        public void addObra(string titulo)
        {
            Obras.Add(titulo);
        }
    }
}
