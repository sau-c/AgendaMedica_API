namespace AgendaMedica.Application.Features.Citas.Command.Agendar
{
    public class AgendarCitaHandler : IRequestHandler<AgendarCitaRequest, bool>
    {
        public AgendarCitaHandler() { }
        public Task<bool> Handle(AgendarCitaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
