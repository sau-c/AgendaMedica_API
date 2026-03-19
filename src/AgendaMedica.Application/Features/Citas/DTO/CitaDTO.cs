namespace AgendaMedica.Application.Features.Citas.DTO
{
    public sealed record CitaDTO(Guid id, DateTime fecha, Guid medicoId, Guid pacienteId);
}
