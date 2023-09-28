using Biblioteca.Domain.Enums;
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
        public EStatusReserva Status { get; set; }
        [JsonIgnore]
        public ulong ClienteId { get; set; }
        public List<ulong>? Obras { get; set; }
    }
}
