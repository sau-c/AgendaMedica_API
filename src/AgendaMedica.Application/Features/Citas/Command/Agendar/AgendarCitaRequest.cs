using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Citas.Command.Agendar
{
    public sealed record AgendarCitaRequest(
        Guid medicoId,
        Guid pacienteId,
        Guid especialidadId,
        DateTime fechaHora,
        string motivo) : IRequest<bool>;
}
