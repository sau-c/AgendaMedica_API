using AgendaMedica.Application.Abstractions;
using AgendaMedica.Application.Features.Pacientes.DTO;

namespace AgendaMedica.Application.Features.Pacientes.Query.Listar
{
    public sealed record ListarPacientesRequest : IRequest<IEnumerable<PacienteDTO>>;
}
