using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Models.Requests
{
    public class AddReservaRequest
    {
        public DateTime DataReserva { get; set; }
        public string Status { get; set; } = null!;
        [JsonIgnore]
        public ulong ClienteId { get; set; }
        public List<ulong>? Obras { get; set; }
    }
}
