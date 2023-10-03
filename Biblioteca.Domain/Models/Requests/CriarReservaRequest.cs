using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests
{
    public class CriarReservaRequest
    {
        [JsonIgnore]
        public ulong ClientId { get; private set; }
        public List<ulong> ObrasId { get; private set; }

        public CriarReservaRequest(ulong clientId, List<ulong> obrasId)
        {
            ClientId = clientId;
            ObrasId = obrasId;
        }

        public void setClientId(ulong clientId)
        {
            ClientId = clientId;
        }
    }
}
