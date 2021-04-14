using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Cancione
    {
        public uint Id { get; set; }
        public uint FkIdAlbum { get; set; }
        public string Titulo { get; set; }
        public uint NumeroDeTrack { get; set; }
        public string Genero { get; set; }
        public string CodigoIsrc { get; set; }
        public uint TamanoEnMb { get; set; }
        public uint Duracion { get; set; }
        public byte ContenidoExplicito { get; set; }
        public string UrlDeUbicacion { get; set; }
        public string Estado { get; set; }

        public virtual Albume FkIdAlbumNavigation { get; set; }
    }
}
