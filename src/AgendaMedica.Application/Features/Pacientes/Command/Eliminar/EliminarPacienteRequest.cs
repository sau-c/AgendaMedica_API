using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Pacientes.Command.Eliminar
{
    public sealed record EliminarPacienteRequest(Guid id) : IRequest<bool>;
}
