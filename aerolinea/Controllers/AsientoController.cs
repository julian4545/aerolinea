using aerolinea.Model;
using aerolinea.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aerolinea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService _asientoService;

        public AsientoController(IAsientoService asientoService)
        {
            _asientoService = asientoService;
        }

        // GET: api/Asiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asiento>>> GetAllAsientos()
        {
            var asientos = await _asientoService.GetAll();
            return Ok(asientos);
        }

        // GET: api/Asiento/5
        [HttpGet("{idAsiento}")]
        public async Task<ActionResult<Asiento>> GetAsiento(int idAsiento)
        {
            var asiento = await _asientoService.Get(idAsiento);

            if (asiento == null)
            {
                return NotFound();
            }

            return Ok(asiento);
        }

        // POST: api/Asiento
        [HttpPost]
        public async Task<ActionResult<Asiento>> CreateAsiento(Asiento asiento)
        {
            var newAsiento = await _asientoService.CreateAsiento(asiento.NumeroAsiento, asiento.AvionId);
            return CreatedAtAction(nameof(GetAsiento), new { id = newAsiento.AsientoId }, newAsiento);
        }

        // PUT: api/Asiento/5
        [HttpPut("{idAsiento}")]
        public async Task<IActionResult> UpdateAsiento(int idAsiento, string NumeroAsiento = null, int? AvionId = null)
        {
            var updatedAsiento = await _asientoService.UpdateAsiento(idAsiento, NumeroAsiento, AvionId);

            if (updatedAsiento == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Asiento/5
        [HttpDelete("{idAsiento}")]
        public async Task<IActionResult> DeleteAsiento(int idAsiento)
        {
            var asiento = await _asientoService.Get(idAsiento);
            if (asiento == null)
            {
                return NotFound();
            }

            await _asientoService.DeleteAsiento(idAsiento);

            return NoContent();
        }
    }
}
