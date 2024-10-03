using LamaAppVS.Context;
using LamaAppVS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MotocicletaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MotocicletaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Motocicleta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Motocicleta>>> GetMotocicletas()
    {
        return await _context.Motocicletas.ToListAsync();
    }

    // GET: api/Motocicleta/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Motocicleta>> GetMotocicleta(int id)
    {
        var motocicleta = await _context.Motocicletas.FindAsync(id);

        if (motocicleta == null)
        {
            return NotFound();
        }

        return motocicleta;
    }
    /*
    // POST: api/Motocicleta
    [HttpPost]
    public async Task<ActionResult<Motocicleta>> PostMotocicleta([FromBody] Motocicleta motocicleta)
    {
        _context.Motocicletas.Add(motocicleta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMotocicleta", new { id = motocicleta.ID_Motocicleta }, motocicleta);
    }

    // PUT: api/Motocicleta/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMotocicleta(int id, [FromBody] Motocicleta motocicleta)
    {
        if (id != motocicleta.ID_Motocicleta)
        {
            return BadRequest();
        }

        _context.Entry(motocicleta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MotocicletaExists(id))
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
    // DELETE: api/Motocicleta/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMotocicleta(int id)
    {
        var motocicleta = await _context.Motocicletas.FindAsync(id);
        if (motocicleta == null)
        {
            return NotFound();
        }

        _context.Motocicletas.Remove(motocicleta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MotocicletaExists(int id)
    {
        return _context.Motocicletas.Any(e => e.ID_Motocicleta == id);
    }
}
