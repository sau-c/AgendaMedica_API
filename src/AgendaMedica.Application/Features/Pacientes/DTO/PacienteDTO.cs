namespace AgendaMedica.Application.Features.Pacientes.DTO
{
    public record class PacienteDTO(
        Guid id,
        string nombre,
        string apellidoPaterno,
        string apellidoMaterno,
        DateOnly fechaNacimiento,
        string correoElectronico
        );
}
