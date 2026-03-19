using AgendaMedica.Domain.CommandRepositories;

namespace AgendaMedica.Application.Features.Pacientes.Command.Eliminar
{
    public class EliminarPacienteHandler : IRequestHandler<EliminarPacienteRequest, bool>
    {
        private readonly IPacienteCommandRepository _pacienteRepo;
        public EliminarPacienteHandler(IPacienteCommandRepository pacienteRepo)
            => _pacienteRepo = pacienteRepo;

        public async Task<bool> Handle(EliminarPacienteRequest request)
            => await _pacienteRepo.EliminarAsync(request.id);
    }
}
