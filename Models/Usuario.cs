using System;
using System.Collections.Generic;

#nullable disable

namespace MSSuscripcion.Models
{
    public partial class Usuario
    {
        public uint Id { get; set; }
        public uint? FkIdArtista { get; set; }
        public string NombreDeUsuario { get; set; }
        public string NombreDelPropietario { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
    }
}
