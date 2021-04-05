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
    public class MSCancionesListaController : ControllerBase
    {

        private libermusiclistasdereproduccionContext dbcontext;

        public MSCancionesListaController()
        {
            dbcontext = new libermusiclistasdereproduccionContext();
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
