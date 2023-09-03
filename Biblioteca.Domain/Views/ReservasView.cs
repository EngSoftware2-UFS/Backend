using Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Views
{
    public class ReservasView
    {
        public ulong Id { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; }
        public string Titulo { get; set; }
        public ulong ClienteId { get; set; }
    }
}
