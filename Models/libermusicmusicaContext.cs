using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class libermusicmusicaContext : DbContext
    {
        public libermusicmusicaContext()
        {
        }

        public libermusicmusicaContext(DbContextOptions<libermusicmusicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albume> Albumes { get; set; }
        public virtual DbSet<Artista> Artistas { get; set; }
        public virtual DbSet<Cancione> Canciones { get; set; }
        public virtual DbSet<Cancioneslistasdereproduccion> Cancioneslistasdereproduccions { get; set; }
        public virtual DbSet<Estatusderegistrosmusica> Estatusderegistrosmusicas { get; set; }
        public virtual DbSet<Listasdereproduccion> Listasdereproduccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3311;database=libermusicmusica;user=admin;pwd=admin", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albume>(entity =>
            {
                entity.ToTable("albumes");

                entity.HasIndex(e => e.FkIdArista, "fk_albumes_artistas1_idx");

                entity.HasIndex(e => e.FkIdEstatus, "fk_albumes_estatusdearchivos1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CompaniaProductora)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("companiaProductora")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Duracion)
                    .HasColumnName("duracion")
                    .HasComment("duracion en segundos");

                entity.Property(e => e.FechaDeLanzamiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeLanzamiento");

                entity.Property(e => e.FkIdArista)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("fkIdArista")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdEstatus)
                    .HasColumnName("fkIdEstatus")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NumeroDeTracks).HasColumnName("numeroDeTracks");

                entity.Property(e => e.TipoDeAlbum)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("tipoDeAlbum")
                    .HasComment("sencillo,edicion especial,etc.")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("titulo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkIdAristaNavigation)
                    .WithMany(p => p.Albumes)
                    .HasForeignKey(d => d.FkIdArista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_albumes_artistas1");

                entity.HasOne(d => d.FkIdEstatusNavigation)
                    .WithMany(p => p.Albumes)
                    .HasForeignKey(d => d.FkIdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_albumes_estatusdearchivos1");
            });

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.ToTable("artistas");

                entity.HasIndex(e => e.FkIdEstatus, "fk_artistas_estatusdearchivos1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AnoDeNacimiento)
                    .HasColumnName("anoDeNacimiento")
                    .HasComment("aÃ±o a partir de la cual el artista empezo su carrera");

                entity.Property(e => e.FkIdEstatus)
                    .HasColumnName("fkIdEstatus")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("nacionalidad")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("nombre")
                    .HasComment("nombre real del arista")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NombreArtistico)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("nombreArtistico")
                    .HasComment("nombre con el que el artista sale en sus discos o canciones(el nombre de)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Web)
                    .HasColumnType("longtext")
                    .HasColumnName("web")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkIdEstatusNavigation)
                    .WithMany(p => p.Artista)
                    .HasForeignKey(d => d.FkIdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_artistas_estatusdearchivos1");
            });

            modelBuilder.Entity<Cancione>(entity =>
            {
                entity.ToTable("canciones");

                entity.HasIndex(e => e.FkIdAlbum, "fk_canciones_albumes1_idx");

                entity.HasIndex(e => e.FkIdEstatus, "fk_canciones_estatusdearchivos1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ContenidoExplicito).HasColumnName("contenidoExplicito");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.FkIdAlbum)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("fkIdAlbum")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdEstatus)
                    .HasColumnName("fkIdEstatus")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("genero")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumeroDeTrack).HasColumnName("numeroDeTrack");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("titulo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkIdAlbumNavigation)
                    .WithMany(p => p.Canciones)
                    .HasForeignKey(d => d.FkIdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_canciones_albumes1");

                entity.HasOne(d => d.FkIdEstatusNavigation)
                    .WithMany(p => p.Canciones)
                    .HasForeignKey(d => d.FkIdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_canciones_estatusdearchivos1");
            });

            modelBuilder.Entity<Cancioneslistasdereproduccion>(entity =>
            {
                entity.ToTable("cancioneslistasdereproduccion");

                entity.HasIndex(e => e.FkIdCancion, "fk_cancioneslistasdereproduccion_canciones1_idx");

                entity.HasIndex(e => e.FkIdEstatus, "fk_cancioneslistasdereproduccion_estatusdearchivos1_idx");

                entity.HasIndex(e => e.FlIdListaDeReproduccion, "fk_cancioneslistasdereproduccion_listasdereproduccion1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdCancion)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("fkIdCancion")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdEstatus)
                    .HasColumnName("fkIdEstatus")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FlIdListaDeReproduccion)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("flIdListaDeReproduccion")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkIdCancionNavigation)
                    .WithMany(p => p.Cancioneslistasdereproduccions)
                    .HasForeignKey(d => d.FkIdCancion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cancioneslistasdereproduccion_canciones1");

                entity.HasOne(d => d.FkIdEstatusNavigation)
                    .WithMany(p => p.Cancioneslistasdereproduccions)
                    .HasForeignKey(d => d.FkIdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cancioneslistasdereproduccion_estatusdearchivos1");

                entity.HasOne(d => d.FlIdListaDeReproduccionNavigation)
                    .WithMany(p => p.Cancioneslistasdereproduccions)
                    .HasForeignKey(d => d.FlIdListaDeReproduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cancioneslistasdereproduccion_listasdereproduccion1");
            });

            modelBuilder.Entity<Estatusderegistrosmusica>(entity =>
            {
                entity.ToTable("estatusderegistrosmusica");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NombreDeEstatus)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("nombreDeEstatus")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Listasdereproduccion>(entity =>
            {
                entity.ToTable("listasdereproduccion");

                entity.HasIndex(e => e.FkIdEstatus, "fk_listasdereproduccion_estatusdearchivos1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdEstatus)
                    .HasColumnName("fkIdEstatus")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FkIdUsuario)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("fkIdUsuario")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("nombre")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumeroDeTracks).HasColumnName("numeroDeTracks");

                entity.HasOne(d => d.FkIdEstatusNavigation)
                    .WithMany(p => p.Listasdereproduccions)
                    .HasForeignKey(d => d.FkIdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_listasdereproduccion_estatusdearchivos1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
