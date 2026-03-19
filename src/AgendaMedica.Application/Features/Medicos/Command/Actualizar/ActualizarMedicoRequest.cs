using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Medicos.Command.Actualizar
{
    public sealed record ActualizarMedicoRequest(
        Guid id,
        string nombre,
        string apellidoPaterno,
        string apellidoMaterno
        ) : IRequest<Guid>;
}
