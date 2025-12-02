using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenBi.Infrastructure.Data;
using ExamenBi;

namespace ExamenBi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoPartidosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventoPartidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoPartido>>> GetEventos()
        {
            return await _context.EventosPartido
                .Include(e => e.Jugador)
                .Include(e => e.Partido)
                .Include(e => e.Evento)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoPartido>> GetEvento(int id)
        {
            var evento = await _context.EventosPartido
                .Include(e => e.Jugador)
                .Include(e => e.Partido)
                .Include(e => e.Evento)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
                return NotFound();

            return evento;
        }

        [HttpPost]
        public async Task<ActionResult<EventoPartido>> PostEvento(EventoPartido evento)
        {
            _context.EventosPartido.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvento), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, EventoPartido evento)
        {
            if (id != evento.Id)
                return BadRequest();

            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.EventosPartido.FindAsync(id);

            if (evento == null)
                return NotFound();

            _context.EventosPartido.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
