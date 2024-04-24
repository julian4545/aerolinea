using aerolinea.Model;
using aerolinea.Repositories;

namespace aerolinea.Services
{
    public interface IReservaService
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva> Get(int ReservaId);
        Task<Reserva> CreateReserva(int PasajeroId, int VueloId, int AsientoId);
        Task<Reserva> UpdateReserva(int ReservaId, int? PasajeroId = null, int? VueloId = null, int? AsientoId = null);
        Task<Reserva> DeleteReserva(int ReservaId);
    }

    public class ReservaService : IReservaService
    {
        private readonly IReservaRepo _reservaRepository;

        public ReservaService(IReservaRepo reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Reserva> CreateReserva(int PasajeroId, int VueloId, int AsientoId)
        {
            return await _reservaRepository.CreateReserva(PasajeroId, VueloId, AsientoId);
        }

        public async Task<List<Reserva>> GetAll()
        {
            return await _reservaRepository.GetAll();
        }

        public async Task<Reserva> Get(int ReservaId)
        {
            return await _reservaRepository.Get(ReservaId);
        }

        public async Task<Reserva> UpdateReserva(int ReservaId, int? PasajeroId = null, int? VueloId = null, int? AsientoId = null)
        {
            Reserva existingReserva = await _reservaRepository.Get(ReservaId);
            if (existingReserva != null)
            {
                if (PasajeroId.HasValue && PasajeroId > 0)
                {
                    existingReserva.PasajeroId = PasajeroId.Value;
                }

                if (VueloId.HasValue && VueloId > 0)
                {
                    existingReserva.VueloId = VueloId.Value;
                }

                if (AsientoId.HasValue && AsientoId > 0)
                {
                    existingReserva.AsientoId = AsientoId.Value;
                }

                return await _reservaRepository.UpdateReserva(existingReserva);
            }
            return null;
        }

        public async Task<Reserva> DeleteReserva(int ReservaId)
        {
            Reserva existingReserva = await _reservaRepository.Get(ReservaId);
            if (existingReserva != null)
            {
                return await _reservaRepository.DeleteReservaAsync(existingReserva);
            }
            return null;
        }
    }
}
