using aerolinea.dbcontext;
using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.Repositories
{
    public interface IPasajeroRepo
    {
        Task<List<Pasajero>> GetAll();
        Task<Pasajero> Get(int PasajeroId);
        Task<Pasajero> CreatePasajero(string Nombre, string Cedula, string Correo);
        Task<Pasajero> UpdatePasajero(Pasajero Pasajero);
        Task<Pasajero> DeletePasajero(Pasajero Pasajero);
    }

    public class PasajeroRepository : IPasajeroRepo
    {
        private readonly AgriversoDbcontext _db;

        public PasajeroRepository(AgriversoDbcontext db)
        {
            _db = db;
        }

        public async Task<Pasajero> CreatePasajero(string Nombre, string Cedula, string Correo)
        {
            Pasajero newPasajero = new Pasajero
            {
                Nombre = Nombre,
                Cedula = Cedula,
                Correo = Correo
            };
            await _db.Pasajero.AddAsync(newPasajero);
            await _db.SaveChangesAsync();
            return newPasajero;
        }

        public async Task<Pasajero> Get(int PasajeroId)
        {
            return await _db.Pasajero.FirstOrDefaultAsync(u => u.PasajeroId == PasajeroId);
        }

        public async Task<List<Pasajero>> GetAll()
        {
            return await _db.Pasajero.ToListAsync();
        }

        public async Task<Pasajero> UpdatePasajero(Pasajero Pasajero)
        {
            _db.Pasajero.Update(Pasajero);
            await _db.SaveChangesAsync();
            return Pasajero;
        }

        public async Task<Pasajero> DeletePasajero(Pasajero Pasajero)
        {
            _db.Pasajero.Remove(Pasajero);
            await _db.SaveChangesAsync();
            return Pasajero;
        }
    }
}
