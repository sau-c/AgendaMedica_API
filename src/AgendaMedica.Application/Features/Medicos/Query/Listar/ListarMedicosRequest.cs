using AgendaMedica.Application.Abstractions;
using AgendaMedica.Application.Features.Medicos.DTO;

namespace AgendaMedica.Application.Features.Medicos.Query.Listar
{
    public sealed record ListarMedicosRequest : IRequest<IEnumerable<MedicoDTO>>;
}
