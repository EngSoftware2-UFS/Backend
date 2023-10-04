using System.Text.Json.Serialization;

namespace Biblioteca.Domain.Models.Requests
{
    public class CriarEmprestimoRequest
    {
        [JsonIgnore]
        public ulong AtendenteId { get; private set; }
        public ulong ClientId { get; private set; }
        public ulong ReservaId { get; private set; }

        public CriarEmprestimoRequest(ulong atendenteId, ulong clientId, ulong reservaId)
        {
            AtendenteId = atendenteId;
            ClientId = clientId;
            ReservaId = reservaId;
        }

        public void setAtendente(ulong atendenteId)
        {
            AtendenteId = atendenteId;
        }
    }
}
