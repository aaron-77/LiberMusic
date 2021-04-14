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
    [Route("[controller]")]
    [ApiController]
    public class MSListasDeReproduccionController : ControllerBase
    {
       /* private libermusiclistasdereproduccionContext dbcontext;
        private readonly ILogger<MSListasDeReproduccionController> log;

        public MSListasDeReproduccionController()
        {
            dbcontext = new libermusiclistasdereproduccionContext();
        }
        //Arreglando los metodos para las listas de reproduccion
        [HttpPost("CrearLista")]
        public async Task<ActionResult<Listasdereproduccion>> add([FromBody] Listasdereproduccion listaReproduccion) {
            if (listaReproduccion == null)
            {
                return BadRequest("No has introducido datos");
            }
            try
            {
                
                    dbcontext.Entry(listaReproduccion).State = EntityState.Added;
                    await dbcontext.SaveChangesAsync();
                    return Created("", listaReproduccion);
             
            }
            catch (Exception ex)
            {
                return BadRequest("Error al registrarte" + "\n" + ex);
            }
        }


        [HttpGet("buscar")]
        public async Task<ActionResult<Listasdereproduccion>> Search([FromQuery] int id = -1, [FromQuery] string nombre = "")
        {


            if (id > -1)
            {

                Validaciones.Validaciones check = new Validaciones.Validaciones();

                if (check.ValidarNúmero(id.ToString()) == Validaciones.Validaciones.ResultadosValidacion.NúmeroVálido)
                {
                    List<Listasdereproduccion> listas = null;

                    listas = await dbcontext.Listasdereproduccions
                        .Where(lista => lista.Nombre.Contains(nombre))
                        .Where(lista => (id >= 0 && lista.Id == id) ||
                        (id < 0 && lista.Id != id))
                        .ToListAsync();

                    if (listas == null)
                    {
                        return BadRequest();
                    }

                    return Ok(listas);
                }
                else
                {
                    return BadRequest("No es un id valido");
                }
            }
            else
            {
                return BadRequest("no ingresó un id para buscar");
            }
        }

        [HttpPut("Eliminar")]
        public async Task<ActionResult<Listasdereproduccion>> delete([FromBody] int id =-1)
        {
            if (id > -1)
            {
                Validaciones.Validaciones check = new Validaciones.Validaciones();


                if (check.ValidarNúmero(id.ToString()) == Validaciones.Validaciones.ResultadosValidacion.NúmeroVálido)
                {


                    var query = (from p in dbcontext.Listasdereproduccions
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
                    return BadRequest("el id no es valido");
                }
            }
            else {
                return BadRequest("no ingresó un id para buscar");
            }
        }*/









    }
}
