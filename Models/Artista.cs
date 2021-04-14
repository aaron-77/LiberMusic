using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Artista
    {
        public Artista()
        {
            Albumes = new HashSet<Albume>();
        }

        public uint Id { get; set; }
        public string Nombre { get; set; }
        public string NombreArtistico { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string Web { get; set; }
        public string Estado { get; set; }
        public string Nacionalidad { get; set; }

        public virtual ICollection<Albume> Albumes { get; set; }
    }
}
