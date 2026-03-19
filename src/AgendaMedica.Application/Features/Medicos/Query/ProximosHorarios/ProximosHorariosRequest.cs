using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Medicos.Query.ProximosHorarios
{
    public sealed record ProximosHorariosRequest(
        Guid id,
        DateOnly fecha
        ) : IRequest<IEnumerable<TimeOnly>>;
}
