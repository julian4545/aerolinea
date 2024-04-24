using aerolinea.Model;
using aerolinea.Repositories;

namespace aerolinea.Services
{
    public interface ITripulacionService
    {
        Task<List<Tripulacion>> GetAll();
        Task<Tripulacion> Get(int TripulacionId);
        Task<Tripulacion> CreateTripulacion(string Nombre, string Rol, int VueloId);
        Task<Tripulacion> UpdateTripulacion(int TripulacionId, string Nombre = null, string Rol = null, int? VueloId = null);
    Task<Tripulacion> DeleteTripulacion(int TripulacionId);
    }

    public class TripulacionService : ITripulacionService
    {
        private readonly ITripulacionRepo _tripulacionRepo;

        public TripulacionService(ITripulacionRepo tripulacionRepo)
        {
            _tripulacionRepo = tripulacionRepo;
        }

        public async Task<Tripulacion> CreateTripulacion(string Nombre, string Rol, int VueloId)
        {
            return await _tripulacionRepo.CreateTripulacion(Nombre, Rol, VueloId);
        }

        public async Task<List<Tripulacion>> GetAll()
        {
            return await _tripulacionRepo.GetAll();
        }

        public async Task<Tripulacion> Get(int TripulacionId)
        {
            return await _tripulacionRepo.Get(TripulacionId);
        }

        public async Task<Tripulacion> UpdateTripulacion(int TripulacionId, string Nombre = null, string Rol = null, int? VueloId = null)
        {
            Tripulacion existingTripulacion = await _tripulacionRepo.Get(TripulacionId);
            if (existingTripulacion != null)
            {
                if (Nombre != null)
                {
                    existingTripulacion.Nombre = Nombre;
                }

                if (Rol != null)
                {
                    existingTripulacion.Rol = Rol;
                }

                if (VueloId.HasValue && VueloId > 0)
                {
                    existingTripulacion.VueloId = VueloId.Value;
                }

                return await _tripulacionRepo.UpdateTripulacion(existingTripulacion);
            }
            return null;
        }

        public async Task<Tripulacion> DeleteTripulacion(int id)
        {
            Tripulacion existingTripulacion = await _tripulacionRepo.Get(id);
            if (existingTripulacion != null)
            {
                return await _tripulacionRepo.DeleteTripulacion(existingTripulacion);
            }
            return null;
        }
    }
}
