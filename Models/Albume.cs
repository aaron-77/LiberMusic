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

        public string Id { get; set; }
        public string FkIdArista { get; set; }
        public string Titulo { get; set; }
        public uint Duracion { get; set; }
        public uint NumeroDeTracks { get; set; }
        public string CompaniaProductora { get; set; }
        public string TipoDeAlbum { get; set; }
        public DateTime? FechaDeLanzamiento { get; set; }
        public uint FkIdEstatus { get; set; }

        public virtual Artista FkIdAristaNavigation { get; set; }
        public virtual Estatusderegistrosmusica FkIdEstatusNavigation { get; set; }
        public virtual ICollection<Cancione> Canciones { get; set; }
    }
}
