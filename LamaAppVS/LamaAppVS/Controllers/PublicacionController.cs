﻿using LamaAppVS.Data;
using LamaAppVS.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PublicacionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PublicacionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Publicacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicaciones()
    {
        return await _context.Publicaciones.ToListAsync();
    }

    // GET: api/Publicacion/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Publicacion>> GetPublicacion(int id)
    {
        var publicacion = await _context.Publicaciones.FindAsync(id);

        if (publicacion == null)
        {
            return NotFound();
        }

        return publicacion;
    }
    /*
    // POST: api/Publicacion
    [HttpPost]
    public async Task<ActionResult<Publicacion>> PostPublicacion([FromBody] Publicacion publicacion)
    {
        _context.Publicaciones.Add(publicacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPublicacion", new { id = publicacion.ID_Publicacion }, publicacion);
    }

    // PUT: api/Publicacion/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPublicacion(int id, [FromBody] Publicacion publicacion)
    {
        if (id != publicacion.ID_Publicacion)
        {
            return BadRequest();
        }

        _context.Entry(publicacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PublicacionExists(id))
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
    // DELETE: api/Publicacion/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublicacion(int id)
    {
        var publicacion = await _context.Publicaciones.FindAsync(id);
        if (publicacion == null)
        {
            return NotFound();
        }

        _context.Publicaciones.Remove(publicacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PublicacionExists(int id)
    {
        return _context.Publicaciones.Any(e => e.ID_Publicacion == id);
    }
}
