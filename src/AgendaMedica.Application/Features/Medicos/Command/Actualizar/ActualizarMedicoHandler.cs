using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.ValueObjects;
using AgendaMedica.Domain.CommandRepositories;
using AgendaMedica.Application.QueryRepositories;

namespace AgendaMedica.Application.Features.Medicos.Command.Actualizar
{
    public class ActualizarMedicoHandler : IRequestHandler<ActualizarMedicoRequest, Guid>
    {
        private readonly IMedicoQueryRepository _medicoQueryRepo;
        private readonly IMedicoCommandRepository _medicoCommandRepo;
        public ActualizarMedicoHandler(
            IMedicoQueryRepository medicoQueryRepo,
            IMedicoCommandRepository medicoCommandRepo
            )
        {
            _medicoQueryRepo = medicoQueryRepo;
            _medicoCommandRepo = medicoCommandRepo;
        }


        public async Task<Guid> Handle(ActualizarMedicoRequest request)
        {
            return Guid.NewGuid();
        }
    }
}
