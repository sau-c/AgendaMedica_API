using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.ValueObjects;
using AgendaMedica.Domain.CommandRepositories;
using AgendaMedica.Application.QueryRepositories;
using AgendaMedica.Application.Features.Pacientes.Command.Actualizar;

namespace AgendaMedica.Application.Features.Medicos.Command.Actualizar
{
    public class ActualizarPacienteHandler : IRequestHandler<ActualizarPacienteRequest, Guid>
    {
        private readonly IMedicoQueryRepository _medicoQueryRepo;
        private readonly IMedicoCommandRepository _medicoCommandRepo;
        public ActualizarPacienteHandler(
            IMedicoQueryRepository medicoQueryRepo,
            IMedicoCommandRepository medicoCommandRepo
            )
        {
            _medicoQueryRepo = medicoQueryRepo;
            _medicoCommandRepo = medicoCommandRepo;
        }


        public async Task<Guid> Handle(ActualizarPacienteRequest request)
        {
            return Guid.NewGuid();
        }
    }
}
