﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class Cancione
    {
        public Cancione()
        {
            Cancioneslistasdereproduccions = new HashSet<Cancioneslistasdereproduccion>();
        }

        public string Id { get; set; }
        public string FkIdAlbum { get; set; }
        public string Titulo { get; set; }
        public uint NumeroDeTrack { get; set; }
        public string Genero { get; set; }
        public uint Duracion { get; set; }
        public byte ContenidoExplicito { get; set; }
        public uint FkIdEstatus { get; set; }

        public virtual Albume FkIdAlbumNavigation { get; set; }
        public virtual Estatusderegistrosmusica FkIdEstatusNavigation { get; set; }
        public virtual ICollection<Cancioneslistasdereproduccion> Cancioneslistasdereproduccions { get; set; }
    }
}
