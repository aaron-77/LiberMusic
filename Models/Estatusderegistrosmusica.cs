using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Estatusderegistrosmusica
    {
        public Estatusderegistrosmusica()
        {
            Albumes = new HashSet<Albume>();
            Artista = new HashSet<Artista>();
            Canciones = new HashSet<Cancione>();
            Cancioneslistasdereproduccions = new HashSet<Cancioneslistasdereproduccion>();
            Listasdereproduccions = new HashSet<Listasdereproduccion>();
        }

        public uint Id { get; set; }
        public string NombreDeEstatus { get; set; }

        public virtual ICollection<Albume> Albumes { get; set; }
        public virtual ICollection<Artista> Artista { get; set; }
        public virtual ICollection<Cancione> Canciones { get; set; }
        public virtual ICollection<Cancioneslistasdereproduccion> Cancioneslistasdereproduccions { get; set; }
        public virtual ICollection<Listasdereproduccion> Listasdereproduccions { get; set; }
    }
}
