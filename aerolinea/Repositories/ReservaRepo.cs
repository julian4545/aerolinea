using aerolinea.dbcontext;
using aerolinea.Model;
using Microsoft.EntityFrameworkCore;

namespace aerolinea.Repositories
{
    public interface IReservaRepo
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva> Get(int ReservaId);
        Task<Reserva> CreateReserva(int PasajeroId, int VueloId, int AsientoId);
        Task<Reserva> UpdateReserva(Reserva Reserva);
        Task<Reserva> DeleteReservaAsync(Reserva Reserva);
    }

    public class ReservaRepository : IReservaRepo
    {
        private readonly AgriversoDbcontext _db;

        public ReservaRepository(AgriversoDbcontext db)
        {
            _db = db;
        }

        public async Task<Reserva> CreateReserva(int PasajeroId, int VueloId, int AsientoId)
        {
            Reserva newReserva = new Reserva
            {
                PasajeroId = PasajeroId,
                VueloId = VueloId,
                AsientoId = AsientoId
            };
            _db.Reserva.Add(newReserva);
            await _db.SaveChangesAsync();
            return newReserva;
        }

        public async Task<Reserva> Get(int ReservaId)
        {
            return await _db.Reserva.FirstOrDefaultAsync(u => u.ReservaId == ReservaId);
        }

        public async Task<List<Reserva>> GetAll()
        {
            return await _db.Reserva.ToListAsync();
        }

        public async Task<Reserva> UpdateReserva(Reserva Reserva)
        {
            _db.Reserva.Update(Reserva);
            await _db.SaveChangesAsync();
            return Reserva;
        }

        public async Task<Reserva> DeleteReservaAsync(Reserva Reserva)
        {
            _db.Reserva.Remove(Reserva);
            await _db.SaveChangesAsync();
            return Reserva;
        }
    }
}
