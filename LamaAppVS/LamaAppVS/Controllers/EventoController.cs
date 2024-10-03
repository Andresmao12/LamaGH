using LamaAppVS.Context;
using LamaAppVS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Evento
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
    {
        return await _context.Eventos.ToListAsync();
    }

    // GET: api/Evento/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> GetEvento(int id)
    {
        var evento = await _context.Eventos.FindAsync(id);

        if (evento == null)
        {
            return NotFound();
        }

        return evento;
    }
    /*
    // POST: api/Evento
    [HttpPost]
    public async Task<ActionResult<Evento>> PostEvento([FromBody] Evento evento)
    {
        _context.Eventos.Add(evento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEvento", new { id = evento.ID_Evento }, evento);
    }

    // PUT: api/Evento/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvento(int id, [FromBody] Evento evento)
    {
        if (id != evento.ID_Evento)
        {
            return BadRequest();
        }

        _context.Entry(evento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }*/

    // DELETE: api/Evento/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvento(int id)
    {
        var evento = await _context.Eventos.FindAsync(id);
        if (evento == null)
        {
            return NotFound();
        }

        _context.Eventos.Remove(evento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventoExists(int id)
    {
        return _context.Eventos.Any(e => e.ID_Evento == id);
    }
}
