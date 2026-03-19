using AgendaMedica.Application.Features.Pacientes.DTO;
using AgendaMedica.Application.QueryRepositories;

namespace AgendaMedica.Application.Features.Pacientes.Query.Listar
{
    public sealed record ListarPacientesHandler : IRequestHandler<ListarPacientesRequest, IEnumerable<PacienteDTO>>
    {
        private readonly IPacienteQueryRepository _pacienteRepo;
        public ListarPacientesHandler(IPacienteQueryRepository pacienteRepo)
            => _pacienteRepo = pacienteRepo;

        public async Task<IEnumerable<PacienteDTO>> Handle(ListarPacientesRequest request)
            => await _pacienteRepo.ListarAsync();
    }
}
