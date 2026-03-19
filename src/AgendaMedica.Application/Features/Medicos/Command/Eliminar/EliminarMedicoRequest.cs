using AgendaMedica.Application.Abstractions;

namespace AgendaMedica.Application.Features.Medicos.Command.Eliminar
{
    public sealed record EliminarMedicoRequest(Guid id) : IRequest<bool>;
}
