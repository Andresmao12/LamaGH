using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LamaApp.Server.Models;
using LamaApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace LamaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapituloController : ControllerBase
    {

        private readonly LamaSqlContext _dbContext;

        public CapituloController(LamaSqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Capitulo
        [HttpGet]
        [Route("Capitulo")]
        public async Task<ActionResult> GetCapitulos()
        {

            var responseApi = new ResponseApi<List<CapituloSh>>();
            var listaCaps = new List<CapituloSh>();

            try
            {
                foreach (var item in await _dbContext.Capitulo.ToListAsync())
                {
                    listaCaps.Add(new CapituloSh
                    {
                        IdCapitulo = item.IdCapitulo,
                        Nombre = item.Nombre,
                        Pais = item.Pais,
                        Ciudad = item.Ciudad,
                    });
                }


                responseApi.response = listaCaps;
                responseApi.statusCode = 200;

            }
            catch (Exception ex)
            {

                responseApi.mensaje = ex.Message;
                responseApi.statusCode = 400;

            }
            return Ok(responseApi);
        }



        // GET: api/Capitulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capitulo>> GetCapitulo(int id)
        {
            var capitulo = await _dbContext.Capitulo.FindAsync(id);

            if (capitulo == null)
            {
                return NotFound();
            }

            return capitulo;
        }

        // POST: api/Capitulo/add
        [HttpPost("add")]
        public async Task<IActionResult> PostCapitulo(CapituloSh capitulo)
        {
            var responseApi = new ResponseApi<CapituloSh>();

            try
            {
                if (string.IsNullOrEmpty(capitulo.Nombre) || string.IsNullOrEmpty(capitulo.Pais) || string.IsNullOrEmpty(capitulo.Ciudad))
                {
                    responseApi.mensaje = "Todos los campos obligatorios deben estar completos.";
                    responseApi.statusCode = 400;
                    return BadRequest(responseApi);
                }

                var nuevoCapitulo = new Capitulo
                {
                    Nombre = capitulo.Nombre,
                    Pais = capitulo.Pais,
                    Ciudad = capitulo.Ciudad
                };

                _dbContext.Capitulo.Add(nuevoCapitulo);
                await _dbContext.SaveChangesAsync();

                responseApi.response = capitulo;
                responseApi.statusCode = 200;
            }
            catch (Exception ex)
            {
                responseApi.mensaje = ex.Message;
                responseApi.statusCode = 400;
            }

            return Ok(responseApi);
        }



        [HttpDelete]
        [Route("deleteCap")]
        public async Task<ActionResult<ResponseApi<bool>>> deleteCapitulo(int idCapitulo)
        {
            var responseApi = new ResponseApi<bool>();

            try
            {
                var capitulo = await _dbContext.Capitulo.FindAsync(idCapitulo);
                if (capitulo == null)
                {
                    responseApi.statusCode = 404;
                    responseApi.mensaje = "Capítulo no encontrado.";
                    return NotFound(responseApi);
                }

                //Eliminamos el capitulo
                _dbContext.Capitulo.Remove(capitulo);
                await _dbContext.SaveChangesAsync();


                responseApi.statusCode = 200;
                responseApi.mensaje = "Capítulo eliminado correctamente.";

                return Ok(responseApi);
            }
            catch (Exception ex)
            {
                responseApi.statusCode = 500;
                responseApi.mensaje = $"Ocurrió un error: {ex.Message}";
                return StatusCode(500, responseApi);
            }
        }


        /*
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostUsuario(UsuarioSh usuario)
        {
            var responseApi = new ResponseApi<int>();

            try
            {

                if (string.IsNullOrEmpty(usuario.NombreUsuario) || string.IsNullOrEmpty(usuario.Contraseña) ||
                   string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Apellido) ||
                   string.IsNullOrEmpty(usuario.Cedula) || usuario.FechaNacimiento == default)
                {
                    responseApi.mensaje = "Todos los campos obligatorios deben estar completos.";
                    responseApi.statusCode = 400;
                    return BadRequest(responseApi);
                }


                var dbUsuario = new Usuario
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = usuario.Contraseña,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Cedula = usuario.Cedula,
                    FechaNacimiento = usuario.FechaNacimiento,
                    FechaRegistro = DateTime.Now,

                    // Mapeo de Contacto
                    Contacto = new Contacto
                    {
                        Direccion = usuario.Contacto.Direccion,
                        Celular = usuario.Contacto.Celular,
                        Correo = usuario.Contacto.Correo,
                    },

                    // Mapeo de Pareja
                    Pareja = new Pareja
                    {
                        Nombre = usuario.Pareja.Nombre,
                        Cedula = usuario.Pareja.Cedula,
                    },

                    // Mapeo de Motocicleta
                    Motocicleta = new Motocicleta
                    {
                        Marca = usuario.Motocicleta.Marca,
                        Modelo = usuario.Motocicleta.Modelo,
                        Placa = usuario.Motocicleta.Placa,
                        Cilindrada = usuario.Motocicleta.Cilindrada,
                    },

                    // Id del capítulo
                    IdCapitulo = usuario.IdCapitulo
                };

                _dbContext.Add(dbUsuario);
                //await _dbContext.SaveChangesAsync();


                try
                {
                    // Intento de guardar cambios
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;
                    Console.WriteLine(innerException?.Message);
                }


                if (dbUsuario.IdUsuario != null)
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
        */
        /*
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
        */
    }
}
