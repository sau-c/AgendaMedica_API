using AgendaMedica.Application.Abstractions;
using AgendaMedica.Application.Features.Pacientes.DTO;

namespace AgendaMedica.Application.Features.Pacientes.Query.ObtenerPorId
{
    public sealed record ObtenerPacientePorIdRequest(Guid id) : IRequest<PacienteDTO>;
}
