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

        public string Id { get; set; }
        public string FkIdUsuario { get; set; }
        public string Nombre { get; set; }
        public uint NumeroDeTracks { get; set; }
        public uint FkIdEstatus { get; set; }

        public virtual Estatusderegistrosmusica FkIdEstatusNavigation { get; set; }
        public virtual ICollection<Cancioneslistasdereproduccion> Cancioneslistasdereproduccions { get; set; }
    }
}
