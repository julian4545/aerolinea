using aerolinea.Model;
using aerolinea.Repositories;

namespace aerolinea.Services
{
    public interface IAsientoService
    {
        Task<List<Asiento>> GetAll();
        Task<Asiento> Get(int AsientoId);
        Task<Asiento> CreateAsiento(string NumeroAsiento, int AvionId);
        
        Task<Asiento> UpdateAsiento(int AsientoId, string NumeroAsiento = null, int? AvionId = null);
        Task<Asiento> DeleteAsiento(int idAsientoId);
    }

    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepo _asientoRepository;

        public AsientoService(IAsientoRepo asientoRepository)
        {
            _asientoRepository = asientoRepository;
        }

        public async Task<Asiento> CreateAsiento(string NumeroAsiento, int AvionId)
        {
            return await _asientoRepository.CreateAsiento(NumeroAsiento, AvionId);
        }

        public async Task<List<Asiento>> GetAll()
        {
            return await _asientoRepository.GetAll();
        }

        public async Task<Asiento> Get(int AsientoId)
        {
            return await _asientoRepository.Get(AsientoId);
        }

        public async Task<Asiento> UpdateAsiento(int AsientoId, string NumeroAsiento = null, int? AvionId = null)
        {
            Asiento existingAsiento = await _asientoRepository.Get(AsientoId);
            if (existingAsiento != null)
            {
                if (NumeroAsiento != null)
                {
                    existingAsiento.NumeroAsiento = NumeroAsiento;
                }

                if (AvionId.HasValue && AvionId > 0)
                {
                    existingAsiento.AvionId = AvionId.Value;
                }

                return await _asientoRepository.UpdateAsiento(existingAsiento);
            }
            return null;
        }


        public async Task<Asiento> DeleteAsiento(int AsientoId)
        {
            Asiento existingAsiento = await _asientoRepository.Get(AsientoId);
            if (existingAsiento != null)
            {
                return await _asientoRepository.DeleteAsientoAsync(existingAsiento);
            }
            return null;
        }
    }
}
