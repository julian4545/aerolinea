using aerolinea.dbcontext;
using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.Repositories
{
    public interface IVueloRepo
    {
        Task<List<Vuelo>> GetAll();
        Task<Vuelo> Get(int VueloId);
        Task<Vuelo> CreateVuelo(string NumeroVuelo, DateTime FechaSalida, DateTime FechaLlegada, string AeropuertoSalida, string AeropuertoLlegada, string EstadoPuntualidad);
        Task<Vuelo> UpdateVuelo(Vuelo Vuelo);
        Task<Vuelo> DeleteVuelo(Vuelo Vuelo);
    }

    public class VueloRepositories : IVueloRepo
    {
        private readonly AgriversoDbcontext _db;

        public VueloRepositories(AgriversoDbcontext db)
        {
            _db = db;
        }

        public async Task<Vuelo> CreateVuelo(string NumeroVuelo, DateTime FechaSalida, DateTime FechaLlegada, string AeropuertoSalida, string AeropuertoLlegada, string EstadoPuntualidad)
        {
            Vuelo newVuelo = new Vuelo
            {
                NumeroVuelo = NumeroVuelo,
                FechaSalida = FechaSalida,
                FechaLlegada = FechaLlegada,
                AeropuertoSalida = AeropuertoSalida,
                AeropuertoLlegada = AeropuertoLlegada,
                EstadoPuntualidad = EstadoPuntualidad
            };
            await _db.Vuelo.AddAsync(newVuelo);
            await _db.SaveChangesAsync();
            return newVuelo;
        }

        public async Task<Vuelo> Get(int VueloId)
        {
            return await _db.Vuelo.FirstOrDefaultAsync(u => u.VueloId == VueloId);
        }

        public async Task<List<Vuelo>> GetAll()
        {
            return await _db.Vuelo.ToListAsync();
        }

        public async Task<Vuelo> UpdateVuelo(Vuelo Vuelo)
        {
            _db.Vuelo.Update(Vuelo);
            await _db.SaveChangesAsync();
            return Vuelo;
        }

        public async Task<Vuelo> DeleteVuelo(Vuelo Vuelo)
        {
            _db.Vuelo.Remove(Vuelo);
            await _db.SaveChangesAsync();
            return Vuelo;
        }
    }
}
