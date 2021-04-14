using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Albume
    {
        public Albume()
        {
            Canciones = new HashSet<Cancione>();
        }

        public uint Id { get; set; }
        public uint FkIdArtista { get; set; }
        public string Titulo { get; set; }
        public uint Duracion { get; set; }
        public uint NumeroDeTracks { get; set; }
        public string CompaniaProductora { get; set; }
        public string TipoDeAlbum { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }
        public string UrlDePortada { get; set; }
        public string Estado { get; set; }

        public virtual Artista FkIdArtistaNavigation { get; set; }
        public virtual ICollection<Cancione> Canciones { get; set; }
    }
}
