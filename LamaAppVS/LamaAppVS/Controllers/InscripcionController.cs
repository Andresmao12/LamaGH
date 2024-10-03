using LamaAppVS.Context;
using LamaAppVS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class InscripcionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InscripcionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Inscripcion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inscripcion>>> GetInscripciones()
    {
        return await _context.Inscripciones.ToListAsync();
    }

    // GET: api/Inscripcion/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Inscripcion>> GetInscripcion(int id)
    {
        var inscripcion = await _context.Inscripciones.FindAsync(id);

        if (inscripcion == null)
        {
            return NotFound();
        }

        return inscripcion;
    }
    /*
    // POST: api/Inscripcion
    [HttpPost]
    public async Task<ActionResult<Inscripcion>> PostInscripcion([FromBody] Inscripcion inscripcion)
    {
        _context.Inscripciones.Add(inscripcion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInscripcion", new { id = inscripcion.ID_Inscripcion }, inscripcion);
    }

    // PUT: api/Inscripcion/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInscripcion(int id, [FromBody] Inscripcion inscripcion)
    {
        if (id != inscripcion.ID_Inscripcion)
        {
            return BadRequest();
        }

        _context.Entry(inscripcion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InscripcionExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    */
    // DELETE: api/Inscripcion/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInscripcion(int id)
    {
        var inscripcion = await _context.Inscripciones.FindAsync(id);
        if (inscripcion == null)
        {
            return NotFound();
        }

        _context.Inscripciones.Remove(inscripcion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InscripcionExists(int id)
    {
        return _context.Inscripciones.Any(e => e.ID_Inscripcion == id);
    }
}
