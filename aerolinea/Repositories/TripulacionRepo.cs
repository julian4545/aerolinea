using aerolinea.dbcontext;
using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.Repositories
{
    public interface ITripulacionRepo
    {
        Task<List<Tripulacion>> GetAll();
        Task<Tripulacion> Get(int TripulacionId);
        Task<Tripulacion> CreateTripulacion(string Nombre, string Rol, int VueloId);
        Task<Tripulacion> UpdateTripulacion(Tripulacion Tripulacion);
        Task<Tripulacion> DeleteTripulacion(Tripulacion Tripulacion);
    }

    public class TripulacionRepositories : ITripulacionRepo
    {
        private readonly AgriversoDbcontext _db;

        public TripulacionRepositories(AgriversoDbcontext db)
        {
            _db = db;
        }

        public async Task<Tripulacion> CreateTripulacion(string Nombre, string Rol, int VueloId)
        {
            Tripulacion newTripulacion = new Tripulacion
            {
                Nombre = Nombre,
                Rol = Rol,
                VueloId = VueloId
            };
            _db.Tripulacion.Add(newTripulacion);
            await _db.SaveChangesAsync();
            return newTripulacion;
        }

        public async Task<Tripulacion> Get(int TripulacionId)
        {
            return await _db.Tripulacion.FirstOrDefaultAsync(u => u.TripulacionId == TripulacionId);
        }

        public async Task<List<Tripulacion>> GetAll()
        {
            return await _db.Tripulacion.ToListAsync();
        }

        public async Task<Tripulacion> UpdateTripulacion(Tripulacion Tripulacion)
        {
            _db.Tripulacion.Update(Tripulacion);
            await _db.SaveChangesAsync();
            return Tripulacion;
        }

        public async Task<Tripulacion> DeleteTripulacion(Tripulacion Tripulacion)
        {
            _db.Tripulacion.Remove(Tripulacion);
            await _db.SaveChangesAsync();
            return Tripulacion;
        }
    }
}
