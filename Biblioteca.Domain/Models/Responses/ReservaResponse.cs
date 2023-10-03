using Biblioteca.Domain.Views;

namespace Biblioteca.Domain.Models.Responses
{
    public class ReservaResponse
    {
        public ulong Id { get; private set; }
        public DateTime DataReserva { get; private set; }
        public string Status { get; private set; } = "";
        public List<ObraShortResponse> Obras { get; private set; } = new List<ObraShortResponse>();
        public ulong? ClienteId { get; private set; } = null;
        public string? ClienteNome { get; private set; } = null;

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
            ClienteNome = reservaView.clienteNome;
            addObra(reservaView.ObraId, reservaView.Titulo);
        }

        public void addObra(ulong obraId, string titulo)
        {
            Obras.Add(new ObraShortResponse(obraId, titulo));
        }

        public void setClienteId(ulong clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
