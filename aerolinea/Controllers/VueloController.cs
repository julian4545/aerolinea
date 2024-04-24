using aerolinea.Model;
using aerolinea.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aerolinea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly IVueloService _vueloService;

        public VueloController(IVueloService vueloService)
        {
            _vueloService = vueloService;
        }

        // GET: api/Vuelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetAllVuelos()
        {
            var vuelos = await _vueloService.GetAll();
            return Ok(vuelos);
        }

        // GET: api/Vuelo/5
        [HttpGet("{idVuelo}")]
        public async Task<ActionResult<Vuelo>> GetVuelo(int idVuelo)
        {
            var vuelo = await _vueloService.Get(idVuelo);

            if (vuelo == null)
            {
                return NotFound();
            }

            return Ok(vuelo);
        }

        // POST: api/Vuelo
        [HttpPost]
        public async Task<ActionResult<Vuelo>> CreateVuelo(Vuelo vuelo)
        {
            var newVuelo = await _vueloService.CreateVuelo(vuelo.NumeroVuelo, vuelo.FechaSalida, vuelo.FechaLlegada, vuelo.AeropuertoSalida, vuelo.AeropuertoLlegada, vuelo.EstadoPuntualidad);
            return CreatedAtAction(nameof(GetVuelo), new { id = newVuelo.VueloId }, newVuelo);
        }

        // PUT: api/Vuelo/5
        [HttpPut("{idVuelo}")]
        public async Task<IActionResult> UpdateVuelo(int idVuelo, string NumeroVuelo = null, DateTime? FechaSalida = null, DateTime? FechaLlegada = null, string AeropuertoSalida = null, string AeropuertoLlegada = null, string EstadoPuntualidad = null)
        {
            var updatedVuelo = await _vueloService.UpdateVuelo(idVuelo, NumeroVuelo, FechaSalida, FechaLlegada, AeropuertoSalida, AeropuertoLlegada, EstadoPuntualidad);

            if (updatedVuelo == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Vuelo/5
        [HttpDelete("{idVuelo}")]
        public async Task<IActionResult> DeleteVuelo(int idVuelo)
        {
            var vuelo = await _vueloService.Get(idVuelo);
            if (vuelo == null)
            {
                return NotFound();
            }

            await _vueloService.DeleteVuelo(idVuelo);

            return NoContent();
        }
    }
}
