using aerolinea.Model;
using aerolinea.Repositories;

namespace aerolinea.Services
{
    public interface IPasajeroService
    {
        Task<List<Pasajero>> GetAll();
        Task<Pasajero> Get(int PasajeroId);
        Task<Pasajero> CreatePasajero(string Nombre, string Cedula, string Correo);
        Task<Pasajero> UpdatePasajero(int PasajeroId, string Nombre = null, string Cedula = null, string Correo = null);
        Task<Pasajero> DeletePasajero(int PasajeroId);
    }

    public class PasajeroService : IPasajeroService
    {
        private readonly IPasajeroRepo _pasajeroRepository;

        public PasajeroService(IPasajeroRepo pasajeroRepository)
        {
            _pasajeroRepository = pasajeroRepository;
        }

        public async Task<Pasajero> CreatePasajero(string Nombre, string Cedula, string Correo)
        {
            return await _pasajeroRepository.CreatePasajero(Nombre, Cedula, Correo);
        }

        public async Task<List<Pasajero>> GetAll()
        {
            return await _pasajeroRepository.GetAll();
        }

        public async Task<Pasajero> Get(int PasajeroId)
        {
            return await _pasajeroRepository.Get(PasajeroId);
        }

        public async Task<Pasajero> UpdatePasajero(int PasajeroId, string Nombre = null, string Cedula = null, string Correo = null)
        {
            Pasajero existingPasajero = await _pasajeroRepository.Get(PasajeroId);
            if (existingPasajero != null)
            {
                if (Nombre != null)
                {
                    existingPasajero.Nombre = Nombre;
                }
                if (Cedula != null)
                {
                    existingPasajero.Cedula = Cedula;
                }
                if (Correo != null)
                {
                    existingPasajero.Correo = Correo;
                }
                return await _pasajeroRepository.UpdatePasajero(existingPasajero);
            }
            return null;
        }

        public async Task<Pasajero> DeletePasajero(int PasajeroId)
        {
            Pasajero existingPasajero = await _pasajeroRepository.Get(PasajeroId);
            if (existingPasajero != null)
            {
                return await _pasajeroRepository.DeletePasajero(existingPasajero);
            }
            return null;
        }
    }
}
