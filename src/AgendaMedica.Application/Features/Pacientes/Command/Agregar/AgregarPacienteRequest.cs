using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Pacientes.Command.Agregar
{
    public sealed record AgregarPacienteRequest(
        string nombre,
        string apellidoPaterno,
        string apellidoMaterno,
        DateOnly fechaNacimiento,
        string numeroTelefono,
        string correoElectronico
        ) : IRequest<Guid>;
}
