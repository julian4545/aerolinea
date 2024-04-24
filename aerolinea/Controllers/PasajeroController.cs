using aerolinea.Model;
using aerolinea.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aerolinea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroController : ControllerBase
    {
        private readonly IPasajeroService _pasajeroService;

        public PasajeroController(IPasajeroService pasajeroService)
        {
            _pasajeroService = pasajeroService;
        }

        // GET: api/Pasajero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasajero>>> GetAllPasajeros()
        {
            var pasajeros = await _pasajeroService.GetAll();
            return Ok(pasajeros);
        }

        // GET: api/Pasajero/5
        [HttpGet("{idPasajero}")]
        public async Task<ActionResult<Pasajero>> GetPasajero(int idPasajero)
        {
            var pasajero = await _pasajeroService.Get(idPasajero);

            if (pasajero == null)
            {
                return NotFound();
            }

            return Ok(pasajero);
        }

        // POST: api/Pasajero
        [HttpPost]
        public async Task<ActionResult<Pasajero>> CreatePasajero(Pasajero pasajero)
        {
            var newPasajero = await _pasajeroService.CreatePasajero(pasajero.Nombre, pasajero.Cedula, pasajero.Correo);
            return CreatedAtAction(nameof(GetPasajero), new { id = newPasajero.PasajeroId }, newPasajero);
        }

        // PUT: api/Pasajero/5
        [HttpPut("{idPasajero}")]
        public async Task<IActionResult> UpdatePasajero(int idPasajero, string Nombre = null, string Cedula = null, string Correo = null)
        {
            var updatedPasajero = await _pasajeroService.UpdatePasajero(idPasajero, Nombre, Cedula, Correo);

            if (updatedPasajero == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Pasajero/5
        [HttpDelete("{idPasajero}")]
        public async Task<IActionResult> DeletePasajero(int idPasajero)
        {
            var pasajero = await _pasajeroService.Get(idPasajero);
            if (pasajero == null)
            {
                return NotFound();
            }

            await _pasajeroService.DeletePasajero(idPasajero);

            return NoContent();
        }
    }
}
