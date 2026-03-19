using AgendaMedica.Domain.Entities;

namespace AgendaMedica.Domain.CommandRepositories
{
    public interface IPacienteCommandRepository
    {
            Task AgregarAsync(Paciente paciente);
            Task ActualizarAsync(Paciente paciente);
            Task<bool> EliminarAsync(Guid id);
    }
}
