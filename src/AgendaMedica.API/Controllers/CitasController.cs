using AgendaMedica.Application.Features.Citas.Command.Agendar;
using AgendaMedica.Application.Features.Citas.Command.Cancelar;
using AgendaMedica.Application.Features.Citas.Query.ConsultarCitas;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitasController(IMediator mediator)
            => _mediator = mediator;

        // POST: api/citas/agendar
        [HttpPost("agendar")]
        public async Task<IActionResult> Agendar(AgendarCitaRequest request)
            => Ok(await _mediator.Send(request));

        // POST: api/citas/cancelar
        [HttpPost("cancelar")]
        public async Task<IActionResult> Cancelar(CancelarCitaRequest request)
            => Ok(await _mediator.Send(request));

        // GET: api/citas/consultar/{id}
        [HttpGet("consultar/{id:guid}")]
        public async Task<IActionResult> Consultar(ConsultarCitaRequest request)
            => Ok(await _mediator.Send(request));

    }
}