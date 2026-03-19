using AgendaMedica.Application.QueryRepositories;
using AgendaMedica.Application.Features.Medicos.DTO;

namespace AgendaMedica.Application.Features.Medicos.Query.ObtenerPorId
{
    public class ObtenerMedicoPorIdHandler : IRequestHandler<ObtenerMedicoPorIdRequest, MedicoDTO>
    {
        private readonly IMedicoQueryRepository _medicoRepo;
        public ObtenerMedicoPorIdHandler(IMedicoQueryRepository medicoRepo)
            => _medicoRepo = medicoRepo;

        public async Task<MedicoDTO> Handle(ObtenerMedicoPorIdRequest request)
            => await _medicoRepo.ObtenerPorIdAsync(request.id);
    }
}
