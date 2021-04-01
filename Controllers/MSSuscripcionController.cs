using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSSuscripcion.Models;
using MSSuscripcion.Validations;

namespace MSSuscripcion.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuscripcionController : ControllerBase
    {
        private libermusicusuariosContext dbContext;
      
        public SuscripcionController() 
        {
            dbContext = new libermusicusuariosContext();
        }

        [HttpGet("login")]
        public async Task<ActionResult<Usuario>> login([FromBody]Usuario usuarioP = null)
        {
            Usuario usuario = null;
            if(String.IsNullOrEmpty(usuarioP.NombreDeUsuario)||String.IsNullOrEmpty( usuarioP.Contrasena) ){
                return BadRequest("No se han ingresado todos los campos");
            }

            ValidadorUsuarios validadorUsuarios = new ValidadorUsuarios();
            bool resultadoValidacion = validadorUsuarios.validarNombre(usuarioP.NombreDeUsuario,ValidadorUsuarios.REGEX_NOMBRE_DE_USUARIO);
            if(resultadoValidacion == false){
               return BadRequest("Datos introducidos no validos"); 
            }

             usuario = await dbContext.Usuarios
                    .Where(user => (user.NombreDeUsuario.Equals(usuarioP.NombreDeUsuario)) && (user.Contrasena.Equals(usuarioP.Contrasena)))
                    .FirstOrDefaultAsync();
                if (usuario == null){            
                    return BadRequest("Usuario y o contraseña incorrectos");
                }
                return Ok(usuario);      
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<ActionResult<Usuario>> Add([FromBody]Usuario usuario)
        {
            if(usuario == null)
            {   
                return BadRequest("No has introducidos datos");
            }
           
            ValidadorUsuarios validadorUsuarios = new ValidadorUsuarios();
            bool resultadoValidacion = validadorUsuarios.validarNombre(usuario.NombreDeUsuario,ValidadorUsuarios.REGEX_NOMBRE_DE_USUARIO)
                                    && validadorUsuarios.validarNombre(usuario.NombreDelPropietario,ValidadorUsuarios.REGEX_NOMBRE)
                                    && validadorUsuarios.validarNombre(usuario.Contrasena,ValidadorUsuarios.REGEX_CONTRASENA)
                                    && validadorUsuarios.validarNombre(usuario.Email,ValidadorUsuarios.REGEX_EMAIL);
            try
            {
                if(resultadoValidacion){
                    dbContext.Entry(usuario).State = EntityState.Added;
                    await dbContext.SaveChangesAsync();
                    return Created("", usuario);
                }else{

                    return BadRequest("Datos introducidos no validos"); 
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error al registrarte"+"\n"+ex);
            }
        }

        [HttpPut("actualizarUsuario")]
        public async Task<ActionResult<Usuario>> update([FromBody]Usuario usuario)
        {
            if(usuario == null)
            {
                return BadRequest("La peticion no contiene datos");
            }
            ValidadorUsuarios validadorUsuarios = new ValidadorUsuarios();
            bool resultadoValidacion = validadorUsuarios.validarNombre(usuario.NombreDeUsuario,ValidadorUsuarios.REGEX_NOMBRE_DE_USUARIO)
                                    && validadorUsuarios.validarNombre(usuario.NombreDelPropietario,ValidadorUsuarios.REGEX_NOMBRE)
                                    && validadorUsuarios.validarNombre(usuario.Contrasena,ValidadorUsuarios.REGEX_CONTRASENA)
                                    && validadorUsuarios.validarNombre(usuario.Email,ValidadorUsuarios.REGEX_EMAIL);
            try
            {   
                if(resultadoValidacion == true){
                    var usuarioDesdeBd = dbContext.Usuarios.SingleOrDefault(c => c.Id == usuario.Id);
                    if(usuarioDesdeBd != null){
                        usuarioDesdeBd.NombreDeUsuario = usuario.NombreDeUsuario;
                        usuarioDesdeBd.NombreDelPropietario = usuario.NombreDelPropietario;
                        usuarioDesdeBd.Contrasena = usuario.Contrasena;
                        usuarioDesdeBd.Email = usuario.Email;
                        usuarioDesdeBd.Pais = usuario.Pais;
                        dbContext.Entry(usuarioDesdeBd).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                        return Ok(usuarioDesdeBd);
                    }else{
                        return BadRequest("Ese usuario no existe");                    
                    }
                }else{
                    return BadRequest("Datos introducidos no validos");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("error al actualizar tus datos"+"\n"+ex);
            }
        }
    }
}