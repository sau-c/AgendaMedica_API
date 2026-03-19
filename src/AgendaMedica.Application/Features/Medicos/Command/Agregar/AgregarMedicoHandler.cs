using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.ValueObjects;
using AgendaMedica.Domain.CommandRepositories;

namespace AgendaMedica.Application.Features.Medicos.Command.Agregar
{
    public class AgregarMedicoHandler : IRequestHandler<AgregarMedicoRequest, Guid>
    {
        private readonly IMedicoCommandRepository _medicoRepo;
        public AgregarMedicoHandler(IMedicoCommandRepository medicoRepo)
            => _medicoRepo = medicoRepo;

        public async Task<Guid> Handle(AgregarMedicoRequest request)
        {
            Medico medico = Medico.Crear(
                Texto.Crear(request.nombre),
                Texto.Crear(request.apellidoPaterno),
                Texto.Crear(request.apellidoMaterno)
            );

            await _medicoRepo.AgregarAsync(medico);
            return medico.Id;
        }
    }
}
