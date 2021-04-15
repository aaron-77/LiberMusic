using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace MSListasDeReproduccion.Controllers
{
    /*[Route("[controller]")]
    [ApiController]
    public class MSCancionesListaController : ControllerBase
    {

        private libermusicmusicaContext dbcontext;
        private readonly ILogger<MSCancionesListaController> log;

        public MSCancionesListaController()
        {
            dbcontext = new libermusicmusicaContext();
        }



        [HttpPost("AgregarCancion")]
        public async Task<ActionResult<Cancioneslistasdereproduccion>> add([FromBody] Cancioneslistasdereproduccion cancionParaLista)
        {
            if (cancionParaLista == null)
            {
                return BadRequest("No has introducido datos");
            }
            try
            {

                dbcontext.Entry(cancionParaLista).State = EntityState.Added;
                await dbcontext.SaveChangesAsync();
                return Created("", cancionParaLista);

            }
            catch (Exception ex)
            {
                return BadRequest("Error al registrarte" + "\n" + ex);
            }

        }

        [HttpGet("buscar")]
        public async Task<ActionResult<Cancioneslistasdereproduccion>> Search([FromQuery] int id =-1)
        {
            if (id > -1)
            {
                Validaciones.Validaciones check = new Validaciones.Validaciones();


                if (check.ValidarNúmero(id.ToString()) == Validaciones.Validaciones.ResultadosValidacion.NúmeroVálido)
                {

                    List<Cancioneslistasdereproduccion> canciones = null;

                    canciones = await dbcontext.Cancioneslistasdereproduccions
                        .Where(cancion => (id >= 0 && cancion.Id == id) || (id < 0 && cancion.Id != id))
                        .ToListAsync();

                    if (canciones == null)
                    {
                        return BadRequest();
                    }

                    return Ok(canciones);
                }
                else
                {
                    return BadRequest("No es un id valida");
                }
            }
            else {
                return BadRequest("no ingresó un id para buscar");
            }
        }

        [HttpPut("Eliminar")]
        public async Task<ActionResult<Cancioneslistasdereproduccion>> delete([FromBody] int id=-1)
        {
            if (id > -1)
            {
                Validaciones.Validaciones check = new Validaciones.Validaciones();
                if (check.ValidarNúmero(id.ToString()) == Validaciones.Validaciones.ResultadosValidacion.NúmeroVálido)
                {
                    var query = (from p in dbcontext.Cancioneslistasdereproduccions
                                 where p.Id == id
                                 select p).Single();
                    try
                    {
                        dbcontext.Remove(query);
                        await dbcontext.SaveChangesAsync();
                        log.LogInformation("se eliminó el registro con el id: {0}", id);
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        log.LogError("Ocurrio un problema:\n" + ex.Message);
                        return BadRequest(ex);

                    }
                }
                else
                {
                    return BadRequest("no es un id valida");
                }
            }
            else {
                return BadRequest("no ingresó un id para buscar");
            }
        }




    }*/
}
