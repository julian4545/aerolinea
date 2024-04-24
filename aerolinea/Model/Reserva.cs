namespace aerolinea.Model
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        public int PasajeroId { get; set; }
        public Pasajero Pasajero { get; set; }

        public int VueloId { get; set; }
        public Vuelo Vuelo { get; set; }

        public int AsientoId { get; set; }
        public Asiento Asiento { get; set; }
    }
}
