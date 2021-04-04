using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSListasDeReproduccion.Models;
using Microsoft.EntityFrameworkCore;

namespace MSListasDeReproduccion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MSListasDeReproduccionController : ControllerBase
    {
        private libermusiclistasdereproduccionContext dbcontext;

        public MSListasDeReproduccionController()
        {
            dbcontext = new libermusiclistasdereproduccionContext();
        }

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





    }
}
