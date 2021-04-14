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

                entity.HasIndex(e => e.FkIdArtista, "fk_albumes_artistas1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompaniaProductora)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("companiaProductora")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Duracion)
                    .HasColumnName("duracion")
                    .HasComment("duracion en segundos");

                entity.Property(e => e.Estado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'activo'")
                    .HasComment("estado del registro (activo,inactivo)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaDeLanzamiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeLanzamiento");

                entity.Property(e => e.FkIdArtista).HasColumnName("fkIdArtista");

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

                entity.Property(e => e.UrlDePortada)
                    .HasColumnType("longtext")
                    .HasColumnName("urlDePortada")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkIdArtistaNavigation)
                    .WithMany(p => p.Albumes)
                    .HasForeignKey(d => d.FkIdArtista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_albumes_artistas1");
            });

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.ToTable("artistas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'activo'")
                    .HasComment("estatus del registro (activo,inactivo)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeNacimiento")
                    .HasComment("fecha a partir de la cual el artista empezo su carrera");

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
            });

            modelBuilder.Entity<Cancione>(entity =>
            {
                entity.ToTable("canciones");

                entity.HasIndex(e => e.FkIdAlbum, "fk_canciones_albumes1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoIsrc)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasColumnName("codigoIsrc")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ContenidoExplicito).HasColumnName("contenidoExplicito");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Estado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'en revision'")
                    .HasComment("estatus del registro(activo,inactivo,en revision)si esta inactivo debe borrarse fisicamente el archivo de la cancion en el servidor. si esta en revision no puede visualizarse en el catalogo de canciones pero si existe en la bd y su archivo de cancion")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdAlbum).HasColumnName("fkIdAlbum");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("genero")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumeroDeTrack).HasColumnName("numeroDeTrack");

                entity.Property(e => e.TamanoEnMb).HasColumnName("tamanoEnMb");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("titulo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UrlDeUbicacion)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("urlDeUbicacion")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.FkIdAlbumNavigation)
                    .WithMany(p => p.Canciones)
                    .HasForeignKey(d => d.FkIdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_canciones_albumes1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
