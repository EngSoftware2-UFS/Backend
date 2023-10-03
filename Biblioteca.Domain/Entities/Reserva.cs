using Biblioteca.Domain.Enums;

namespace Biblioteca.Domain.Entities;

public partial class Reserva
{
    public ulong Id { get; set; }

    public DateTime DataReserva { get; set; }

    public string Status { get; set; } = null!;

    public ulong ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;


    public void CriarReserva(ulong clienteId)
    {
        DataReserva = DateTime.Now;
        Status = EStatusReserva.ATIVA.ToString();
        ClienteId = clienteId;
    }

    public void CancelarReserva()
    {
        Status = EStatusReserva.CANCELADA.ToString();
    }

    public void FinalizarReserva()
    {
        Status = EStatusReserva.FINALIZADA.ToString();
    }
}
