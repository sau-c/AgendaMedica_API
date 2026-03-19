using AgendaMedica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Infrastructure.Persistence.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");

            builder.HasKey(m => m.Id);

            builder.OwnsOne(m => m.Nombre, nombre =>
            {
                nombre.Property(n => n.Valor)
                      .HasColumnName("Nombre")
                      .IsRequired()
                      .HasMaxLength(100);
            });

            builder.OwnsOne(m => m.ApellidoPaterno, apellidoP =>
            {
                apellidoP.Property(a => a.Valor)
                         .HasColumnName("ApellidoPaterno")
                         .IsRequired()
                         .HasMaxLength(100);
            });

            builder.OwnsOne(m => m.ApellidoMaterno, apellidoM =>
            {
                apellidoM.Property(a => a.Valor)
                         .HasColumnName("ApellidoMaterno")
                         .IsRequired()
                         .HasMaxLength(100);
            });

            builder.HasMany(m => m.Especialidades)
                .WithMany()
                .UsingEntity(j => j.ToTable("MedicoEspecialidad"));

            builder.OwnsMany(m => m.HorariosConsulta, h =>
            {
                h.ToTable("HorarioConsulta");

                h.WithOwner().HasForeignKey("MedicoId");

                h.Property(p => p.DiaSemana)
                    .IsRequired();

                h.Property(p => p.HoraInicio)
                    .IsRequired();

                h.Property(p => p.HoraFin)
                    .IsRequired();
            });

            // Navegaciones requeridas
            builder.Navigation(m => m.Nombre).IsRequired();
            builder.Navigation(m => m.ApellidoPaterno).IsRequired();
            builder.Navigation(m => m.ApellidoMaterno).IsRequired();
        }
    }
}