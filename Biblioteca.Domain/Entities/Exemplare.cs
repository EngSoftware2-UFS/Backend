namespace Biblioteca.Domain.Entities;

public partial class Exemplare
{
    public ulong Id { get; set; }

    public bool Disponivel { get; set; }

    public ulong ObraId { get; set; }

    public void CriarReserva()
    {
        Disponivel = false;
    }

    public void CancelarReserva()
    {
        Disponivel = true;
    }
}
