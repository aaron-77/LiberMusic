using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MSSuscripcion.Models
{
    public partial class libermusicusuariosContext : DbContext
    {
        public libermusicusuariosContext()
        {
        }

        public libermusicusuariosContext(DbContextOptions<libermusicusuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
              
                optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.23-mysql"),
                    builder => {
                        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("contrasena")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Estado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("estado")
                    .HasDefaultValueSql("'activo'")
                    .HasComment("estatus de guardado(activo,inactivo)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FkIdArtista).HasColumnName("fkIdArtista");

                entity.Property(e => e.NombreDeUsuario)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("nombreDeUsuario")
                    .HasComment("nombre de usuario(nickname) de la cuenta que se esta creando")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NombreDelPropietario)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("nombreDelPropietario")
                    .HasComment("nombre de la persona a quien pertenece la cuenta de usuario")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("pais")
                    .HasComment("pais de origen del usuario")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
