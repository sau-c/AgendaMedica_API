using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Infrastructure.Persistence.Configurations
{
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            builder.ToTable("Especialidad");

            builder.HasKey(e => e.Id);

            // ===== Value Object: Nombre =====
            builder.OwnsOne(e => e.Nombre, nombre =>
            {
                nombre.Property(n => n.Valor)
                      .HasColumnName("Nombre")
                      .IsRequired()
                      .HasMaxLength(200);
            });

            // ===== Propiedad simple =====
            builder.Property(e => e.DuracionConsultaMinutos)
                   .IsRequired();

            // ===== Navegación requerida =====
            builder.Navigation(e => e.Nombre).IsRequired();

        }
    }
}