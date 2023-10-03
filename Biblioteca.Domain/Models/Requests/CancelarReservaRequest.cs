using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests
{
    public class CancelarReservaRequest
    {
        [JsonIgnore]
        public ulong ClientId { get; private set; }
        public ulong ReservaId { get; private set; }

        public CancelarReservaRequest(ulong clientId, ulong reservaId)
        {
            ClientId = clientId;
            ReservaId = reservaId;
        }

        public void setClientId(ulong clientId)
        {
            ClientId = clientId;
        }
    }
}
