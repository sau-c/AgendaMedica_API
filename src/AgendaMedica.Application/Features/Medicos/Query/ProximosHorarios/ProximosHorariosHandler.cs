using AgendaMedica.Application.QueryRepositories;

namespace AgendaMedica.Application.Features.Medicos.Query.ProximosHorarios
{
    public class ProximosHorariosHandler : IRequestHandler<ProximosHorariosRequest, IEnumerable<TimeOnly>>
    {
        private readonly IMedicoQueryRepository _medicoRepo;
        public ProximosHorariosHandler(IMedicoQueryRepository medicoRepo)
            => _medicoRepo = medicoRepo;

        public Task<IEnumerable<TimeOnly>> Handle(ProximosHorariosRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
