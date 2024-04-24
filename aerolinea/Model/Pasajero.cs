namespace aerolinea.Model
{
    public class Pasajero
    {
        public int PasajeroId { get; set; }
        public required string Nombre { get; set; }

        public string? Cedula { get; set; }

        public string? Correo { get; set; }
        public string? cuidad { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
