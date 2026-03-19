using AgendaMedica.Domain.ValueObjects;

namespace AgendaMedica.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public Texto Nombre { get; private set; }
        public Texto ApellidoPaterno { get; private set; }
        public Texto ApellidoMaterno { get; private set; }
        public DateOnly FechaNacimiento { get; private set; }
        public NumeroTelefono Telefono { get; private set; }
        public CorreoElectronico CorreoElectronico { get; private set; }

        private Paciente() { }
        private Paciente(
            Texto nombre,
            Texto apellidoPaterno,
            Texto apellidoMaterno,
            DateOnly fechaNacimiento,
            NumeroTelefono telefono,
            CorreoElectronico correoElectronico
            )
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
        }

        public static Paciente Crear(
            Texto nombre,
            Texto apellidoPaterno,
            Texto apellidoMaterno,
            DateOnly fechaNacimiento,
            NumeroTelefono telefono,
            CorreoElectronico correoElectronico
            )
        {
            return new Paciente(
                nombre, 
                apellidoPaterno, 
                apellidoMaterno, 
                fechaNacimiento, 
                telefono, 
                correoElectronico);
        }
    }
}
