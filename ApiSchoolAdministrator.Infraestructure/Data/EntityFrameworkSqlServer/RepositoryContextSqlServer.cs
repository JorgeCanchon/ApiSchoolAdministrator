using ApiSchoolAdministrator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchoolAdministrator.Infraestructure.Data.EntityFrameworkSqlServer
{
    public class RepositoryContextSqlServer : DbContext
    {
        public RepositoryContextSqlServer()
        {

        }
        public RepositoryContextSqlServer(DbContextOptions options)
            : base(options)
        {

        }
        public virtual DbSet<AlumnoAsignatura> AlumnoAsignatura { get; set; }
        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (modelBuilder != null)
            {
                modelBuilder.Entity<AlumnoAsignatura>(entity =>
                {
                    entity.HasNoKey();

                    entity.Property(e => e.CodigoAsignatura)
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    entity.HasOne(d => d.IdAlumnoNavigation)
                        .WithMany()
                        .HasForeignKey(d => d.IdAlumno)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AlumnoAsi__IdAlu__4CA06362");

                    entity.HasOne(d => d.IdProfesorNavigation)
                        .WithMany()
                        .HasForeignKey(d => d.IdProfesor)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AlumnoAsi__IdPro__4D94879B");
                });

                modelBuilder.Entity<Asignatura>(entity =>
                {
                    entity.HasKey(e => e.Codigo)
                        .HasName("PK__Asignatu__06370DAD88A1C67B");

                    entity.Property(e => e.Codigo)
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    entity.Property(e => e.Nombre)
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);
                });

                modelBuilder.Entity<Persona>(entity =>
                {
                    entity.Property(e => e.Apellido)
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    entity.Property(e => e.Direccion)
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    entity.Property(e => e.Nombre)
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);
                });

                modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.IdentityColumn);
            }
        }
    }
}
