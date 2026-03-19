using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Pacientes.Command.Actualizar
{
    public sealed record ActualizarPacienteRequest(
        Guid id,
        string nombre,
        string apellidoPaterno,
        string apellidoMaterno,
        DateOnly fechaNacimiento,
        string numeroTelefono,
        string correoElectronico
        ) : IRequest<Guid>;
}
