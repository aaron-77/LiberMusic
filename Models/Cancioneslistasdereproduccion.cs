using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Cancioneslistasdereproduccion
    {
        public string Id { get; set; }
        public string FkIdCancion { get; set; }
        public string FlIdListaDeReproduccion { get; set; }
        public uint FkIdEstatus { get; set; }

        public virtual Cancione FkIdCancionNavigation { get; set; }
        public virtual Estatusderegistrosmusica FkIdEstatusNavigation { get; set; }
        public virtual Listasdereproduccion FlIdListaDeReproduccionNavigation { get; set; }
    }
}
