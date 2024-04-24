namespace aerolinea.Model
{
    public class Asiento
    {

        public int AsientoId { get; set; }
        public string NumeroAsiento { get; set; }

        public int AvionId { get; set; }
        public Avion Avion { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
