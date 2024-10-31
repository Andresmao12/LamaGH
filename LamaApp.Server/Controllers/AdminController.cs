using LamaApp.Server.Models;
using LamaApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LamaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly LamaSqlContext _dbContext;

        public AdminController(LamaSqlContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("getStats")]
        public async Task<ResponseApi<Estadisticas>> getStats()
        {
            var responseApi = new ResponseApi<Estadisticas>();

            try
            {

                //Total de usuarios registrados
                var totalUsuarios = await _dbContext.Usuario.CountAsync();

                //Total de capitulos ingresados
                var totalCapitulos = await _dbContext.Capitulo.CountAsync();

                //Lista de los capitulos con sus respectivos atributos
                var listaCapitulos = await _dbContext.Capitulo
                    .Select(c => new CapituloSh
                    {
                        IdCapitulo = c.IdCapitulo,
                        Nombre = c.Nombre,
                        Pais = c.Pais,
                        Ciudad = c.Ciudad
                    })
                    .ToListAsync();

                //En que capitulo hay mas usuarios registrados
                var capituloConMasUsuarios = await _dbContext.Capitulo
                    .OrderByDescending(c => c.Usuarios.Count())
                    .Select(e => e.Nombre)
                    .FirstOrDefaultAsync();

                // Usuarios por capítulo, generando un string
                var usuariosPorCapitulo = await _dbContext.Capitulo
                    .Select(c => new
                    {
                        NombreCapitulo = c.Nombre,
                        TotalUsuarios = c.Usuarios.Count()
                    })
                    .OrderByDescending(c => c.TotalUsuarios) // Ordenar por total de usuarios
                    .ToListAsync();

                // Convertir a una lista de strings en el formato "Nombre,Total"
                var usuariosPorCapituloStrings = usuariosPorCapitulo
                    .Select(c => $"{c.NombreCapitulo},{c.TotalUsuarios}")
                    .ToList();




                //En que lugar se realizan mas eventos
                var lugarConMasEventos = await _dbContext.Evento
                    .GroupBy(e => e.Ubicacion)
                    .OrderByDescending(g => g.Count())
                    .Select(g => new { Ubicacion = g.Key, NumeroEventos = g.Count() })
                    .FirstOrDefaultAsync();


                var eventosPorCapitulo = await _dbContext.Evento
                            .GroupBy(e => e.IdCapitulo) 
                            .Select(g => new
                            {
                                NombreCapitulo = g.Select(e => e.Capitulo.Nombre).FirstOrDefault(), // Obtener el nombre del capítulo
                                TotalEventos = g.Count()
                            })
                            .OrderByDescending(g => g.TotalEventos) // Ordenar por total de eventos
                            .ToListAsync();

                // Convertir a lista de strings para eventos
                var eventosPorCapituloStrings = eventosPorCapitulo
                    .Select(c => $"{c.NombreCapitulo},{c.TotalEventos}")
                    .ToList();




                responseApi.response = new Estadisticas
                {
                    TotalUsuarios = totalUsuarios,
                    TotalCapitulos = totalCapitulos,
                    listaCapitulos = listaCapitulos,
                    CapituloConMasUsuarios = capituloConMasUsuarios,
                    usuariosPorCapitulo = usuariosPorCapituloStrings, // Lista<string> en formato "Nombre,Total"
                    eventosPorCapitulo = eventosPorCapituloStrings, // Lista<string> en formato "Nombre,Total"
                };

                responseApi.statusCode = 200;

            }
            catch (Exception ex)
            {
                responseApi.statusCode = 500;
                responseApi.mensaje = "Ocurrio un error obteniendo los datos";

            }

            return responseApi;


        }



    }
}
