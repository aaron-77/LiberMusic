using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Listasdereproduccion
    {
        public Listasdereproduccion()
        {
            Cancioneslistasdereproduccions = new HashSet<Cancioneslistasdereproduccion>();
        }

        public uint Id { get; set; }
        public uint? FkIdUsuario { get; set; }
        public string Nombre { get; set; }
        public uint NumeroDeTracks { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Cancioneslistasdereproduccion> Cancioneslistasdereproduccions { get; set; }
    }
}
