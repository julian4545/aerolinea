using aerolinea.Model;
using aerolinea.Repositories;

namespace aerolinea.Services
{
    public interface IVueloService
    {
        Task<List<Vuelo>> GetAll();
        Task<Vuelo> Get(int VueloId);
        Task<Vuelo> CreateVuelo(string NumeroVuelo, DateTime FechaSalida, DateTime FechaLlegada, string AeropuertoSalida, string AeropuertoLlegada, string EstadoPuntualidad);
        Task<Vuelo> UpdateVuelo(int VueloId, string NumeroVuelo = null, DateTime? FechaSalida = null, DateTime? FechaLlegada = null, string AeropuertoSalida = null, string AeropuertoLlegada = null, string EstadoPuntualidad = null);
        Task<Vuelo> DeleteVuelo(int VueloId);
    }

    public class VueloService : IVueloService
    {
        private readonly IVueloRepo _vueloRepo;

        public VueloService(IVueloRepo vueloRepo)
        {
            _vueloRepo = vueloRepo;
        }

        public async Task<Vuelo> CreateVuelo(string NumeroVuelo, DateTime FechaSalida, DateTime FechaLlegada, string AeropuertoSalida, string AeropuertoLlegada, string EstadoPuntualidad)
        {
            return await _vueloRepo.CreateVuelo(NumeroVuelo, FechaSalida, FechaLlegada, AeropuertoSalida, AeropuertoLlegada, EstadoPuntualidad);
        }

        public async Task<List<Vuelo>> GetAll()
        {
            return await _vueloRepo.GetAll();
        }

        public async Task<Vuelo> Get(int VueloId)
        {
            return await _vueloRepo.Get(VueloId);
        }

        public async Task<Vuelo> UpdateVuelo(int VueloId, string NumeroVuelo = null, DateTime? FechaSalida = null, DateTime? FechaLlegada = null, string AeropuertoSalida = null, string AeropuertoLlegada = null, string EstadoPuntualidad = null)
        {
            Vuelo existingVuelo = await _vueloRepo.Get(VueloId);
            if (existingVuelo != null)
            {
                if (NumeroVuelo != null)
                {
                    existingVuelo.NumeroVuelo = NumeroVuelo;
                }

                if (FechaSalida.HasValue)
                {
                    existingVuelo.FechaSalida = FechaSalida.Value;
                }

                if (FechaLlegada.HasValue)
                {
                    existingVuelo.FechaLlegada = FechaLlegada.Value;
                }

                if (AeropuertoSalida != null)
                {
                    existingVuelo.AeropuertoSalida = AeropuertoSalida;
                }

                if (AeropuertoLlegada != null)
                {
                    existingVuelo.AeropuertoLlegada = AeropuertoLlegada;
                }

                if (EstadoPuntualidad != null)
                {
                    existingVuelo.EstadoPuntualidad = EstadoPuntualidad;
                }

                return await _vueloRepo.UpdateVuelo(existingVuelo);
            }
            return null;
        }

        public async Task<Vuelo> DeleteVuelo(int VueloId)
        {
            Vuelo existingVuelo = await _vueloRepo.Get(VueloId);
            if (existingVuelo != null)
            {
                return await _vueloRepo.DeleteVuelo(existingVuelo);
            }
            return null;
        }
    }
}
