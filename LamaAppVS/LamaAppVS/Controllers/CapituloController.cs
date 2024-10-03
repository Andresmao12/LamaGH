using LamaAppVS.Context;
using LamaAppVS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CapituloController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CapituloController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Capitulo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Capitulo>>> GetCapitulos()
    {
        return await _context.Capitulos.ToListAsync();
    }

    // GET: api/Capitulo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Capitulo>> GetCapitulo(int id)
    {
        var capitulo = await _context.Capitulos.FindAsync(id);

        if (capitulo == null)
        {
            return NotFound();
        }

        return capitulo;
    }

    // POST: api/Capitulo
    /*[HttpPost]
    public async Task<ActionResult<Capitulo>> PostCapitulo([FromBody] Capitulo capitulo)
    {
        _context.Capitulos.Add(capitulo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCapitulo", new { id = capitulo.ID_Capitulo }, capitulo);
    }

    // PUT: api/Capitulo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCapitulo(int id, [FromBody] Capitulo capitulo)
    {
        if (id != capitulo.ID_Capitulo)
        {
            return BadRequest();
        }

        _context.Entry(capitulo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CapituloExists(id))
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

    // DELETE: api/Capitulo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCapitulo(int id)
    {
        var capitulo = await _context.Capitulos.FindAsync(id);
        if (capitulo == null)
        {
            return NotFound();
        }

        _context.Capitulos.Remove(capitulo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CapituloExists(int id)
    {
        return _context.Capitulos.Any(e => e.ID_Capitulo == id);
    }
}
