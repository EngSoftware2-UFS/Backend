namespace Biblioteca.Domain.Views
{
    public class ReservasView
    {
        public ulong Id { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; }
        public string Titulo { get; set; }
        public ulong ObraId { get; set; }
        public ulong ClienteId { get; set; }
        public string clienteNome { get; set; }
    }
}
