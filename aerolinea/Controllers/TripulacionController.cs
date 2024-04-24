using aerolinea.Model;
using aerolinea.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aerolinea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripulacionController : ControllerBase
    {
        private readonly ITripulacionService _tripulacionService;

        public TripulacionController(ITripulacionService tripulacionService)
        {
            _tripulacionService = tripulacionService;
        }

        // GET: api/Tripulacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tripulacion>>> GetAllTripulaciones()
        {
            var tripulaciones = await _tripulacionService.GetAll();
            return Ok(tripulaciones);
        }

        // GET: api/Tripulacion/5
        [HttpGet("{idTripulacion}")]
        public async Task<ActionResult<Tripulacion>> GetTripulacion(int idTripulacion)
        {
            var tripulacion = await _tripulacionService.Get(idTripulacion);

            if (tripulacion == null)
            {
                return NotFound();
            }

            return Ok(tripulacion);
        }

        // POST: api/Tripulacion
        [HttpPost]
        public async Task<ActionResult<Tripulacion>> CreateTripulacion(Tripulacion tripulacion)
        {
            var newTripulacion = await _tripulacionService.CreateTripulacion(tripulacion.Nombre, tripulacion.Rol, tripulacion.VueloId);
            return CreatedAtAction(nameof(GetTripulacion), new { id = newTripulacion.TripulacionId }, newTripulacion);
        }

        // PUT: api/Tripulacion/5
        [HttpPut("{idTripulacion}")]
        public async Task<IActionResult> UpdateTripulacion(int idTripulacion, string Nombre = null, string Rol = null, int? VueloId = null)
        {
            var updatedTripulacion = await _tripulacionService.UpdateTripulacion(idTripulacion, Nombre, Rol, VueloId);

            if (updatedTripulacion == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Tripulacion/5
        [HttpDelete("{idTripulacion}")]
        public async Task<IActionResult> DeleteTripulacion(int idTripulacion)
        {
            var tripulacion = await _tripulacionService.Get(idTripulacion);
            if (tripulacion == null)
            {
                return NotFound();
            }

            await _tripulacionService.DeleteTripulacion(idTripulacion);

            return NoContent();
        }
    }
}
