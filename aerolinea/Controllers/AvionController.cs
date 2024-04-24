using aerolinea.Model;
using aerolinea.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aerolinea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvionController : ControllerBase
    {
        private readonly IAvionService _avionService;

        public AvionController(IAvionService avionService)
        {
            _avionService = avionService;
        }

        // GET: api/Avion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avion>>> GetAllAviones()
        {
            var aviones = await _avionService.GetAll();
            return Ok(aviones);
        }

        // GET: api/Avion/5
        [HttpGet("{idAvion}")]
        public async Task<ActionResult<Avion>> GetAvion(int idAvion)
        {
            var avion = await _avionService.Get(idAvion);

            if (avion == null)
            {
                return NotFound();
            }

            return Ok(avion);
        }

        // POST: api/Avion
        [HttpPost]
        public async Task<ActionResult<Avion>> CreateAvion(Avion avion)
        {
            var newAvion = await _avionService.CreateAvion(avion.Modelo, avion.CapacidadMaximaPasajeros);
            return CreatedAtAction(nameof(GetAvion), new { id = newAvion.AvionId }, newAvion);
        }

        // PUT: api/Avion/5
        [HttpPut("{idAvion}")]
        public async Task<IActionResult> UpdateAvion(int idAvion, string Modelo = null, int? CapacidadMaximaPasajeros = null)
        {
            var updatedAvion = await _avionService.UpdateAvion(idAvion, Modelo, CapacidadMaximaPasajeros);

            if (updatedAvion == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Avion/5
        [HttpDelete("{idAvion}")]
        public async Task<IActionResult> DeleteAvion(int idAvion)
        {
            var avion = await _avionService.Get(idAvion);
            if (avion == null)
            {
                return NotFound();
            }

            await _avionService.DeleteAvion(idAvion);

            return NoContent();
        }
    }
}
