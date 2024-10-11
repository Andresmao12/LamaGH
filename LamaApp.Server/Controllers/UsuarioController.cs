using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LamaApp.Server.Models;
using LamaApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace LamaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly LamaSqlContext _dbContext;

        public UsuarioController(LamaSqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Usuario
        [HttpGet]
        [Route("Usuario")]
        public async Task<ActionResult> GetUsuarios()
        {

            var responseApi = new ResponseApi<List<UsuarioSh>>();
            var listaUsuarios = new List<UsuarioSh>();

            try
            {
                foreach (var item in await _dbContext.Usuarios.ToListAsync())
                {
                    listaUsuarios.Add(new UsuarioSh
                    {
                        IdUsuario = item.IdUsuario,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Cedula = item.Cedula,
                        //Falta agregar los demas valores
                    });
                }


                responseApi.response = listaUsuarios;
                responseApi.statusCode = 200;

            }
            catch (Exception ex)
            {

                responseApi.mensaje = ex.Message;
                responseApi.statusCode = 400;

            }

            return Ok(responseApi);
            //return await _dbContext.Usuarios.ToListAsync();
        }



        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }


        [HttpPost]
        [Route("Usuario")]
        public async Task<IActionResult> PostUsuario(UsuarioSh usuario)
        {
            var responseApi = new ResponseApi<int>();

            try
            {

                var dbUsuario = new UsuarioSh
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = usuario.Contraseña,
                    Apellido = usuario.Apellido,
                    Cedula = usuario.Cedula,
                    FechaNacimiento = usuario.FechaNacimiento,
                    FechaRegistro = DateTime.Now,
                    Contacto = new ContactoSh()
                    {
                        Direccion = usuario.Contacto.Direccion,
                        Celular = usuario.Contacto.Celular,
                        Correo = usuario.Contacto.Correo,
                    },
                    Pareja = new ParejaSh()
                    {
                        Nombre = usuario.Pareja.Nombre,
                        Cedula = usuario.Pareja.Cedula,
                    },
                    Motocicleta = new MotocicletaSh()
                    {
                        Marca = usuario.Motocicleta.Marca,
                        Modelo = usuario.Motocicleta.Modelo,
                        Placa = usuario.Motocicleta.Placa,
                        Cilindrada = usuario.Motocicleta.Cilindrada,
                    },
                    IdCapitulo = usuario.IdCapitulo
                };

                _dbContext.Add(dbUsuario);
                await _dbContext.SaveChangesAsync();

                if (dbUsuario.IdUsuario != 0)
                {
                    responseApi.response = dbUsuario.IdUsuario;
                    responseApi.statusCode = 200;
                }
                else
                {
                    responseApi.mensaje = "Ocurrio un error guardando el usuario";
                    responseApi.statusCode = 400;
                }
            }
            catch (Exception ex)
            {

                responseApi.mensaje = ex.Message;
                responseApi.statusCode = 400;

            }

            return Ok(responseApi);
        }


        /*
        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.ID_Usuario }, usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.ID_Usuario)
            {
                return BadRequest();
            }

            _dbContext.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _dbContext.Usuarios.Any(e => e.IdUsuario == id);
        }

    }
}
