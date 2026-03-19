using AgendaMedica.Application.Abstractions;
using AgendaMedica.Application.Features.Citas.DTO;

namespace AgendaMedica.Application.Features.Citas.Query.ConsultarCitas
{
    public sealed record ConsultarCitaRequest(Guid id) : IRequest<CitaDTO>;
}
