using AgendaMedica.Application.Abstractions;
using AgendaMedica.Application.Features.Medicos.DTO;

namespace AgendaMedica.Application.Features.Medicos.Query.ObtenerPorId
{
    public sealed record ObtenerMedicoPorIdRequest(Guid id) : IRequest<MedicoDTO>;
}
