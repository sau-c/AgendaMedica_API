using AgendaMedica.Application.QueryRepositories;
using AgendaMedica.Application.Features.Pacientes.DTO;

namespace AgendaMedica.Application.Features.Pacientes.Query.ObtenerPorId
{
    public class ObtenerPacientePorIdHandler : IRequestHandler<ObtenerPacientePorIdRequest, PacienteDTO>
    {
        private readonly IPacienteQueryRepository _pacienteRepo;
        public ObtenerPacientePorIdHandler(IPacienteQueryRepository pacienteRepo)
            => _pacienteRepo = pacienteRepo;

        public async Task<PacienteDTO> Handle(ObtenerPacientePorIdRequest request)
            => await _pacienteRepo.ObtenerPorIdAsync(request.id);
    }
}
