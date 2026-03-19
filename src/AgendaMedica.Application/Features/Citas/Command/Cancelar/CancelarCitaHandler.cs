namespace AgendaMedica.Application.Features.Citas.Command.Cancelar
{
    public class CancelarCitaHandler : IRequestHandler<CancelarCitaRequest, bool>
    {
        //private readonly ICitaRepository _citaRepo;
        public CancelarCitaHandler()
        {
            
        }

        public Task<bool> Handle(CancelarCitaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
