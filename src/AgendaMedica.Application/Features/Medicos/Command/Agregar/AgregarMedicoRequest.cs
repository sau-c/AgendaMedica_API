using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Medicos.Command.Agregar
{
    public sealed record AgregarMedicoRequest(
        string nombre,
        string apellidoPaterno,
        string apellidoMaterno
        ) : IRequest<Guid>;
}
