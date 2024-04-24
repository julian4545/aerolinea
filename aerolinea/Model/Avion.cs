namespace aerolinea.Model
{
    public class Avion
    {
        public int AvionId { get; set; }
        public string Modelo { get; set; }
        public int CapacidadMaximaPasajeros { get; set; }

        public ICollection<Asiento> Asientos { get; set; }
    }
}
