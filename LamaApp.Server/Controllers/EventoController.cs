using Microsoft.AspNetCore.Mvc;
using LamaApp.Server.Models;
using LamaApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace LamaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly LamaSqlContext _dbContext;
        public EventoController(LamaSqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> ObtenerEventos()
        {
            var responseApi = new ResponseApi<List<Evento>>();
            var listEvents = new List<Evento>();

            try
            {
                foreach (var item in await _dbContext.Evento.ToListAsync())
                {
                    listEvents.Add(new Evento
                    {
                        IdEvento = item.IdEvento,
                        FechaInicio = item.FechaInicio,
                        FechaFin = item.FechaFin,
                        Ubicacion = item.Ubicacion,
                        Creador = item.Creador,
                        Descripcion = item.Descripcion,
                        IdCapitulo = item.IdCapitulo,
                    });
                }


                responseApi.response = listEvents;
                responseApi.statusCode = 200;

            }
            catch (Exception ex)
            {

                responseApi.mensaje = ex.Message;
                responseApi.statusCode = 400;

            }
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AgregarEvento(Evento evento)
        {
            var responseApi = new ResponseApi<Evento>();

            try
            {
                if (
                    string.IsNullOrEmpty(evento.FechaInicio.ToString()) || 
                    string.IsNullOrEmpty(evento.FechaFin.ToString()) || 
                    string.IsNullOrEmpty(evento.Ubicacion) ||
                    string.IsNullOrEmpty(evento.Descripcion) ||
                    string.IsNullOrEmpty(evento.IdCapitulo.ToString())
                    )
                {
                    responseApi.mensaje = "Todos los campos obligatorios deben estar completos.";
                    responseApi.statusCode = 400;
                    return BadRequest(responseApi);
                }

                var nuevoEvento = new Evento
                {
                    FechaInicio = evento.FechaInicio,
                    FechaFin = evento.FechaFin,
                    Ubicacion = evento.Ubicacion,
                    Creador = "lama",
                    Descripcion = evento.Descripcion,
                    IdCapitulo = evento.IdCapitulo,
                };

                _dbContext.Evento.Add(nuevoEvento);
                await _dbContext.SaveChangesAsync();

                responseApi.response = nuevoEvento;
                responseApi.statusCode = 200;
            }
            catch (Exception ex)
            {
                responseApi.mensaje = ex.Message;
                responseApi.statusCode = 400;
            }

            return Ok(responseApi);


        }

        
    }
}
