using AgendaMedica.Application.Features.Medicos.DTO;
using AgendaMedica.Domain.Entities;

namespace AgendaMedica.Application.QueryRepositories
{
    public interface IMedicoQueryRepository
    {
        Task<IEnumerable<MedicoDTO>> ListarAsync();
        Task<MedicoDTO> ObtenerPorIdAsync(Guid id);
        //Task<IEnumerable<MedicoDTO>> BuscarPorEspecialidadAsync(string especialidad);
        //Task<IEnumerable<MedicoDTO>> BuscarPorNombreAsync(string nombre);
        //Task<IEnumerable<MedicoDTO>> BuscarPorApellidoAsync(string apellido);
        //Task<IEnumerable<MedicoDTO>> BuscarPorNombreCompletoAsync(string nombreCompleto);
        //Task<IEnumerable<MedicoDTO>> BuscarPorDisponibilidadAsync(DateTime fecha);
        //Task<IEnumerable<MedicoDTO>> BuscarPorUbicacionAsync(string ubicacion);
    }
}
