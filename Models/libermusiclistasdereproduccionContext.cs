using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MSListasDeReproduccion.Models
{
    public partial class libermusiclistasdereproduccionContext : DbContext
    {
        public libermusiclistasdereproduccionContext()
        {
        }

        public libermusiclistasdereproduccionContext(DbContextOptions<libermusiclistasdereproduccionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cancioneslistasdereproduccion> Cancioneslistasdereproduccions { get; set; }
        public virtual DbSet<Listasdereproduccion> Listasdereproduccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3312;database=libermusiclistasdereproduccion;user=admin;pwd=admin", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancioneslistasdereproduccion>(entity =>
            {
                entity.ToTable("cancioneslistasdereproduccion");

                entity.HasIndex(e => e.FkListaDeReproduccion, "fk_cancioneslistadereproduccion_listasdereproduccion1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'activo'")
                    .HasComment("estatus del registro (activo,inactivo)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdCancion).HasColumnName("fkIdCancion");

                entity.Property(e => e.FkListaDeReproduccion).HasColumnName("fkListaDeReproduccion");

                entity.HasOne(d => d.FkListaDeReproduccionNavigation)
                    .WithMany(p => p.Cancioneslistasdereproduccions)
                    .HasForeignKey(d => d.FkListaDeReproduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cancioneslistadereproduccion_listasdereproduccion1");
            });

            modelBuilder.Entity<Listasdereproduccion>(entity =>
            {
                entity.ToTable("listasdereproduccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'activo'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdUsuario).HasColumnName("fkIdUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("nombre")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumeroDeTracks).HasColumnName("numeroDeTracks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
