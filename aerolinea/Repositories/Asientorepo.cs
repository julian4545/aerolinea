using aerolinea.dbcontext;
using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.Repositories
{
    public interface IAsientoRepo
    {
        Task<List<Asiento>> GetAll();
        Task<Asiento> Get(int AsientoId);
        Task<Asiento> CreateAsiento(string NumeroAsiento, int AvionId);
        Task<Asiento> UpdateAsiento(Asiento Asiento);
        Task<Asiento> DeleteAsientoAsync(Asiento Asiento);
    }

    public class AsientoRepository : IAsientoRepo
    {
        private readonly AgriversoDbcontext _db;

        public AsientoRepository(AgriversoDbcontext db)
        {
            _db = db;
        }

        public async Task<Asiento> CreateAsiento(string NumeroAsiento, int AvionId)
        {
            Asiento newAsiento = new Asiento
            {
                NumeroAsiento = NumeroAsiento,
                AvionId = AvionId
            };
            _db.Asiento.Add(newAsiento);
            await _db.SaveChangesAsync();
            return newAsiento;
        }

        public async Task<Asiento> Get(int AsientoId)
        {
            return await _db.Asiento.FirstOrDefaultAsync(u => u.AsientoId == AsientoId);
        }

        public async Task<List<Asiento>> GetAll()
        {
            return await _db.Asiento.ToListAsync();
        }

        public async Task<Asiento> UpdateAsiento(Asiento Asiento)
        {
            _db.Asiento.Update(Asiento);
            await _db.SaveChangesAsync();
            return Asiento;
        }

        public async Task<Asiento> DeleteAsientoAsync(Asiento Asiento)
        {
            _db.Asiento.Remove(Asiento);
            await _db.SaveChangesAsync();
            return Asiento;
        }
    }
}
