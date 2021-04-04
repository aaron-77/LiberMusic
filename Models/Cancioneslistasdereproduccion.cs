using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Cancioneslistasdereproduccion
    {
        public uint Id { get; set; }
        public uint FkIdCancion { get; set; }
        public uint FkListaDeReproduccion { get; set; }
        public string Estado { get; set; }

        public virtual Listasdereproduccion FkListaDeReproduccionNavigation { get; set; }
    }
}
