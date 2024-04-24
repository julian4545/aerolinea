using aerolinea.Model;
using aerolinea.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aerolinea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetAllReservas()
        {
            var reservas = await _reservaService.GetAll();
            return Ok(reservas);
        }

        // GET: api/Reserva/5
        [HttpGet("{idReserva}")]
        public async Task<ActionResult<Reserva>> GetReserva(int idReserva)
        {
            var reserva = await _reservaService.Get(idReserva);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // POST: api/Reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> CreateReserva(Reserva reserva)
        {
            var newReserva = await _reservaService.CreateReserva(reserva.PasajeroId, reserva.VueloId, reserva.AsientoId);
            return CreatedAtAction(nameof(GetReserva), new { id = newReserva.ReservaId }, newReserva);
        }

        // PUT: api/Reserva/5
        [HttpPut("{idReserva}")]
        public async Task<IActionResult> UpdateReserva(int idReserva, int PasajeroId = 0, int VueloId = 0, int AsientoId = 0)
        {
            var updatedReserva = await _reservaService.UpdateReserva(idReserva, PasajeroId, VueloId, AsientoId);

            if (updatedReserva == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{idReserva}")]
        public async Task<IActionResult> DeleteReserva(int idReserva)
        {
            var reserva = await _reservaService.Get(idReserva);
            if (reserva == null)
            {
                return NotFound();
            }

            await _reservaService.DeleteReserva(idReserva);

            return NoContent();
        }
    }
}
