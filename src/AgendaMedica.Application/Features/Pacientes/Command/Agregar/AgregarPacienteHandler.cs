using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.ValueObjects;
using AgendaMedica.Domain.CommandRepositories;

namespace AgendaMedica.Application.Features.Pacientes.Command.Agregar
{
    public class AgregarPacienteHandler : IRequestHandler<AgregarPacienteRequest, Guid>
    {
        private readonly IPacienteCommandRepository _pacienteRepo;
        public AgregarPacienteHandler(IPacienteCommandRepository pacienteRepo)
            => _pacienteRepo = pacienteRepo;

        public async Task<Guid> Handle(AgregarPacienteRequest request)
        {
            Paciente paciente = Paciente.Crear(
                Texto.Crear(request.nombre),
                Texto.Crear(request.apellidoPaterno),
                Texto.Crear(request.apellidoMaterno),
                request.fechaNacimiento,
                NumeroTelefono.Crear(request.numeroTelefono),
                CorreoElectronico.Crear(request.correoElectronico)
            );

            await _pacienteRepo.AgregarAsync(paciente);
            return paciente.Id;
        }
    }
}
