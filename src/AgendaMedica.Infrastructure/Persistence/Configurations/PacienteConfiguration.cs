using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Infrastructure.Persistence.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.HasKey(p => p.Id);

            // ===== Nombre =====
            builder.OwnsOne(p => p.Nombre, nombre =>
            {
                nombre.Property(n => n.Valor)
                      .HasColumnName("Nombre")
                      .IsRequired()
                      .HasMaxLength(100);
            });

            builder.OwnsOne(p => p.ApellidoPaterno, apellidoP =>
            {
                apellidoP.Property(a => a.Valor)
                         .HasColumnName("ApellidoPaterno")
                         .IsRequired()
                         .HasMaxLength(100);
            });

            builder.OwnsOne(p => p.ApellidoMaterno, apellidoM =>
            {
                apellidoM.Property(a => a.Valor)
                         .HasColumnName("ApellidoMaterno")
                         .IsRequired()
                         .HasMaxLength(100);
            });

            // ===== Fecha =====
            builder.Property(p => p.FechaNacimiento)
                   .IsRequired();

            // ===== Telefono =====
            builder.OwnsOne(p => p.Telefono, telefono =>
            {
                telefono.Property(t => t.Valor)
                        .HasColumnName("Telefono")
                        .IsRequired()
                        .HasMaxLength(20);
            });

            // ===== Correo =====
            builder.OwnsOne(p => p.CorreoElectronico, correo =>
            {
                correo.Property(c => c.Valor)
                      .HasColumnName("CorreoElectronico")
                      .IsRequired()
                      .HasMaxLength(150);
            });

            // Navegaciones requeridas
            builder.Navigation(p => p.Nombre).IsRequired();
            builder.Navigation(p => p.ApellidoPaterno).IsRequired();
            builder.Navigation(p => p.ApellidoMaterno).IsRequired();
            builder.Navigation(p => p.Telefono).IsRequired();
            builder.Navigation(p => p.CorreoElectronico).IsRequired();
        }
    }
}