namespace aerolinea.Model
{
    public class Vuelo
    {
        public int VueloId { get; set; }
        public string NumeroVuelo { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string AeropuertoSalida { get; set; }
        public string AeropuertoLlegada { get; set; }
        public string EstadoPuntualidad { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Tripulacion> Tripulacion { get; set; }
    }
}
