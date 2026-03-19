using AgendaMedica.Application.Features.Medicos.Command.Actualizar;
using AgendaMedica.Application.Features.Medicos.Command.Agregar;
using AgendaMedica.Application.Features.Medicos.Command.Eliminar;
using AgendaMedica.Application.Features.Medicos.DTO;
using AgendaMedica.Application.Features.Medicos.Query.Listar;
using AgendaMedica.Application.Features.Medicos.Query.ObtenerPorId;
using AgendaMedica.Application.Features.Medicos.Query.ProximosHorarios;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicosController(IMediator mediator)
            => _mediator = mediator;

        // GET: api/medicos
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new ListarMedicosRequest()));

        // POST: api/medicos
        [HttpPost]
        public async Task<IActionResult> Add(AgregarMedicoRequest request)
            => Ok(await _mediator.Send(request));

        // GET: api/medicos/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            MedicoDTO medico = await _mediator.Send(new ObtenerMedicoPorIdRequest(id));
            if (medico == null)
                return NotFound();

            return Ok(medico);
        }

        // GET: api/medicos/horarios?{id}?{fecha}
        [HttpGet("horarios/{id:guid}/{fecha}")]
        public async Task<IActionResult> GetProximosHorarios(ProximosHorariosRequest request)
            => Ok(await _mediator.Send(request));

        // GET: api/agenda/medico/{medicoId}/fecha/{fecha}
        [HttpGet("agenda/{id:guid}/{fecha}")]
        public IActionResult GetAgendaPorMedicoYFecha(Guid id, DateTime fecha)
        {
            // Lógica para obtener todas las citas de un médico en un día, ordenadas por hora
            return Ok(/* resultado */);
        }

        // PUT: api/medicos/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(ActualizarMedicoRequest request)
            => Ok(await _mediator.Send(request));

        // DELETE: api/medicos/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new EliminarMedicoRequest(id));
            return NoContent();
        }
    }
}