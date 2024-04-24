using aerolinea.dbcontext;
using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.Repositories
{
    public interface IAvionRepo
    {
        Task<List<Avion>> GetAll();
        Task<Avion> Get(int AvionId);
        Task<Avion> CreateAvion(string Modelo, int CapacidadMaximaPasajeros);
        Task<Avion> UpdateAvion(Avion Avion);
        Task<Avion> DeleteAvionAsync(Avion Avion);
    }

    public class AvionRepository : IAvionRepo
    {
        private readonly AgriversoDbcontext _db;

        public AvionRepository(AgriversoDbcontext db)
        {
            _db = db;
        }

        public async Task<Avion> CreateAvion(string Modelo, int CapacidadMaximaPasajeros)
        {
            Avion newAvion = new Avion
            {
                Modelo = Modelo,
                CapacidadMaximaPasajeros = CapacidadMaximaPasajeros
            };
            _db.Avion.Add(newAvion);
            await _db.SaveChangesAsync();
            return newAvion;
        }

        public async Task<Avion> Get(int AvionId)
        {
            return await _db.Avion.FirstOrDefaultAsync(u => u.AvionId == AvionId);
        }

        public async Task<List<Avion>> GetAll()
        {
            return await _db.Avion.ToListAsync();
        }

        public async Task<Avion> UpdateAvion(Avion Avion)
        {
            _db.Avion.Update(Avion);
            await _db.SaveChangesAsync();
            return Avion;
        }

        public async Task<Avion> DeleteAvionAsync(Avion Avion)
        {
            _db.Avion.Remove(Avion);
            await _db.SaveChangesAsync();
            return Avion;
        }
    }
}
