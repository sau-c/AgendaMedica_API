using AgendaMedica.Domain.CommandRepositories;

namespace AgendaMedica.Application.Features.Medicos.Command.Eliminar
{
    public class EliminarMedicoHandler : IRequestHandler<EliminarMedicoRequest, bool>
    {
        private readonly IMedicoCommandRepository _medicoRepo;
        public EliminarMedicoHandler(IMedicoCommandRepository medicoRepo)
            => _medicoRepo = medicoRepo;

        public async Task<bool> Handle(EliminarMedicoRequest request)
            => await _medicoRepo.EliminarAsync(request.id);
         
    }
}
