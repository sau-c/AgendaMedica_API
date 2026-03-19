namespace AgendaMedica.Application.Features.Medicos.DTO
{
    public record class MedicoDTO(
        Guid id,
        string nombre,
        string apellidoPaterno,
        string apellidoMaterno,
        IEnumerable<string> especialidades,
        IEnumerable<string> horariosConsulta
        );
}
