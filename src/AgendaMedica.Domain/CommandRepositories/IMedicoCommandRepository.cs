using AgendaMedica.Domain.Entities;

namespace AgendaMedica.Domain.CommandRepositories
{
    public interface IMedicoCommandRepository
    {
        Task AgregarAsync(Medico medico);
        Task ActualizarAsync(Medico medico);
        Task<bool> EliminarAsync(Guid id);
    }
}
