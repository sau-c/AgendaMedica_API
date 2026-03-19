using AgendaMedica.Application.Features.Pacientes.DTO;

namespace AgendaMedica.Application.QueryRepositories
{
    public interface IPacienteQueryRepository
    {
        Task<IEnumerable<PacienteDTO>> ListarAsync();
        Task<PacienteDTO> ObtenerPorIdAsync(Guid id);
    }
}
