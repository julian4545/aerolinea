using aerolinea.Model;
using aerolinea.Repositories;

namespace aerolinea.Services
{
    public interface IAvionService
    {
        Task<List<Avion>> GetAll();
        Task<Avion> Get(int AvionId);
        Task<Avion> CreateAvion(string Modelo, int CapacidadMaximaPasajeros);
        Task<Avion> UpdateAvion(int AvionId, string Modelo = null, int? CapacidadMaximaPasajeros = null);
        Task<Avion> DeleteAvion(int AvionId);
    }

    public class AvionService : IAvionService
    {
        private readonly IAvionRepo _avionRepository;

        public AvionService(IAvionRepo avionRepository)
        {
            _avionRepository = avionRepository;
        }

        public async Task<Avion> CreateAvion(string Modelo, int CapacidadMaximaPasajeros)
        {
            return await _avionRepository.CreateAvion(Modelo, CapacidadMaximaPasajeros);
        }

        public async Task<List<Avion>> GetAll()
        {
            return await _avionRepository.GetAll();
        }

        public async Task<Avion> Get(int AvionId)
        {
            return await _avionRepository.Get(AvionId);
        }

        public async Task<Avion> UpdateAvion(int AvionId, string Modelo = null, int? CapacidadMaximaPasajeros = null)
        {
            Avion existingAvion = await _avionRepository.Get(AvionId);
            if (existingAvion != null)
            {
                if (Modelo != null)
                {
                    existingAvion.Modelo = Modelo;
                }

                if (CapacidadMaximaPasajeros.HasValue && CapacidadMaximaPasajeros > 0)
                {
                    existingAvion.CapacidadMaximaPasajeros = CapacidadMaximaPasajeros.Value;
                }

                return await _avionRepository.UpdateAvion(existingAvion);
            }
            return null;
        }

        public async Task<Avion> DeleteAvion(int AvionId)
        {
            Avion existingAvion = await _avionRepository.Get(AvionId);
            if (existingAvion != null)
            {
                return await _avionRepository.DeleteAvionAsync(existingAvion);
            }
            return null;
        }
    }
}
