using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSListasDeReproduccion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MSListasDeReproduccion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MSListasDeReproduccionController : ControllerBase
    {
        private libermusicmusicaContext dbcontext;
        private readonly ILogger<MSListasDeReproduccionController> log;

        public MSListasDeReproduccionController()
        {
            dbcontext = new libermusicmusicaContext();
        }
        //Arreglando los metodos para las listas de reproduccion



        [HttpPost("CrearLista")]
        public async Task<ActionResult<Listasdereproduccion>> add([FromBody] Listasdereproduccion listaReproduccion)
        {
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


        [HttpGet("buscarLista")]
        public async Task<ActionResult<Listasdereproduccion>> Search([FromQuery] string nombre = "", [FromQuery] string idUsuario = "")
        {

            List<Listasdereproduccion> listas = null;

            listas = await dbcontext.Listasdereproduccions
                .Where(lista => lista.Nombre.Contains(nombre)).Where(lista => lista.FkIdUsuario.Equals(idUsuario)).ToListAsync();

            if (listas == null)
            {
                return BadRequest();
            }

            return Ok(listas);

        }


        [HttpPut("ActualizarLista")]
        public async Task<ActionResult<Listasdereproduccion>> update([FromBody] Listasdereproduccion lista)
        {
            if (lista == null)
            {
                log.LogError("No se encontro la lista a actualizar");
                return BadRequest("lista de reproduccion no encontrada");
            }

            try
            {
                var milista = dbcontext.Listasdereproduccions.SingleOrDefault(c => c.Id.Equals(lista.Id));
                milista = lista;
                await dbcontext.SaveChangesAsync();

                log.LogInformation("Se actualizo la lista: {0}", lista.Nombre);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                log.LogError("Ocurrio un problema:\n" + ex.Message);
                return BadRequest(ex);
            }
        }



        [HttpPut("EliminarCancion")]
        public async Task<ActionResult<Cancioneslistasdereproduccion>> update([FromBody] string idlista, string idcancion)
        {


            try
            {
                var micancionlista = dbcontext.Cancioneslistasdereproduccions.SingleOrDefault(c => c.FkIdCancion.Equals(idcancion) && c.FlIdListaDeReproduccion.Equals(idlista));
                micancionlista.FkIdEstatus = 2;

                await dbcontext.SaveChangesAsync();

                log.LogInformation("Se actualizo la lista: {0}", idcancion);
                return Ok();
            }
            catch (Exception ex)
            {
                log.LogError("Ocurrio un problema:\n" + ex.Message);
                return BadRequest(ex);
            }
        }



        //Regresar las caciones solamente.
        [HttpGet("MostrarCanciones")]
        public async Task<ActionResult<Cancioneslistasdereproduccion>> Search([FromQuery] string idLista = "")
        {

            List<Cancioneslistasdereproduccion> canciones = null;

            canciones = await dbcontext.Cancioneslistasdereproduccions.Where(cancion => cancion.FlIdListaDeReproduccion.Equals(idLista)).ToListAsync();

            if (canciones == null)
            {
                return BadRequest();
            }

            return Ok(canciones);

        }



        [HttpPost("AgregarCancionLista")]
        public async Task<ActionResult<Cancioneslistasdereproduccion>> add([FromBody] Cancioneslistasdereproduccion cancionLista)
        {
            if (cancionLista == null)
            {
                return BadRequest("No has introducido datos");
            }
            try
            {

                dbcontext.Entry(cancionLista).State = EntityState.Added;
                await dbcontext.SaveChangesAsync();
                return Created("", cancionLista);

            }
            catch (Exception ex)
            {
                return BadRequest("Error al registrarte" + "\n" + ex);












            }
        }
    }
}
