namespace aerolinea.Model
{
    public class Tripulacion
    {
        public int TripulacionId { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public int VueloId { get; set; }
        public Vuelo Vuelo { get; set; }
    }
}
