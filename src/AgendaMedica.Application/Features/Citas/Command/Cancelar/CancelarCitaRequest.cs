using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Citas.Command.Cancelar
{
    public sealed record CancelarCitaRequest(
        Guid id,
        string motivoCancelacion
        ) : IRequest<bool>;
}
