using AgendaMedica.Domain.ValueObjects;

namespace AgendaMedica.Domain.Entities
{
    public class Especialidad : BaseEntity
    {
        public Texto Nombre { get; private set; }
        public int DuracionConsultaMinutos { get; private set; }

        // Constructor privado para EFcore
        private Especialidad() { }

        private Especialidad(Texto nombre, int duracionConsultaMinutos)
        {
            Nombre = nombre;
            SetDuracionConsulta(duracionConsultaMinutos);
        }

        public static Especialidad Crear(Texto nombre, int duracionConsultaMinutos)
        {
            return new Especialidad(
                nombre,
                duracionConsultaMinutos
            );
        }

        // Comportamiento de dominio
        public void CambiarNombre(Texto nuevoNombre)
        {
            Nombre = nuevoNombre;
        }

        public void CambiarDuracionConsulta(int nuevaDuracion)
        {
            SetDuracionConsulta(nuevaDuracion);
        }

        private void SetDuracionConsulta(int duracion)
        {
            if (duracion <= 0)
                throw new ArgumentException("La duración de la consulta debe ser mayor a 0 minutos.");

            DuracionConsultaMinutos = duracion;
        }
    }
}