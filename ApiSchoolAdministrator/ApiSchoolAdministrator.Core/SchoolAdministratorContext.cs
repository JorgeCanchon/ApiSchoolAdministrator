using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiSchoolAdministrator.Entities;

namespace ApiSchoolAdministrator.ApiSchoolAdministrator.Core
{
    public partial class SchoolAdministratorContext : DbContext
    {
        public SchoolAdministratorContext()
        {
        }

        public SchoolAdministratorContext(DbContextOptions<SchoolAdministratorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlumnoAsignatura> AlumnoAsignatura { get; set; }
        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Password=0p3r@zst##Sql;Persist Security Info=True;User ID=sa;Initial Catalog=SchoolAdministrator;Data Source=AZDESAR01");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
