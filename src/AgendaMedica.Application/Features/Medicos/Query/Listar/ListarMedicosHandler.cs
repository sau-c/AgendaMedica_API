using AgendaMedica.Application.Features.Medicos.DTO;
using AgendaMedica.Application.QueryRepositories;

namespace AgendaMedica.Application.Features.Medicos.Query.Listar
{
    public sealed record ListarMedicosHandler : IRequestHandler<ListarMedicosRequest, IEnumerable<MedicoDTO>>
    {
        private readonly IMedicoQueryRepository _medicoRepo;
        public ListarMedicosHandler(IMedicoQueryRepository medicoRepo)
            => _medicoRepo = medicoRepo;

        public async Task<IEnumerable<MedicoDTO>> Handle(ListarMedicosRequest request)
            => await _medicoRepo.ListarAsync();
    }
}
