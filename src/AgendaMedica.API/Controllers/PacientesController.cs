using AgendaMedica.Application.Features.Medicos.Command.Actualizar;
using AgendaMedica.Application.Features.Medicos.Command.Agregar;
using AgendaMedica.Application.Features.Medicos.Command.Eliminar;
using AgendaMedica.Application.Features.Medicos.Query.Listar;
using AgendaMedica.Application.Features.Medicos.Query.ObtenerPorId;
using AgendaMedica.Application.Features.Pacientes.Command.Actualizar;
using AgendaMedica.Application.Features.Pacientes.Command.Agregar;
using AgendaMedica.Application.Features.Pacientes.Command.Eliminar;
using AgendaMedica.Application.Features.Pacientes.DTO;
using AgendaMedica.Application.Features.Pacientes.Query.Listar;
using AgendaMedica.Application.Features.Pacientes.Query.ObtenerPorId;
using AgendaMedica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PacientesController(IMediator mediator)
            => _mediator = mediator;

        // GET: api/pacientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new ListarPacientesRequest()));

        // POST: api/pacientes
        [HttpPost]
        public async Task<IActionResult> Add(AgregarPacienteRequest request)
            => Ok(await _mediator.Send(request));

        // GET: api/pacientes/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            PacienteDTO paciente = await _mediator.Send(new ObtenerPacientePorIdRequest(id));
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        // GET: api/paciente/{id}
        [HttpGet("historial/{id:guid}")]
        public IActionResult GetHistorialPorPaciente(Guid id)
        {
            // Lógica para obtener todas las citas de un paciente
            return Ok(/* resultado */);
        }

        // PUT: api/paciente/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(ActualizarPacienteRequest request)
            => Ok(await _mediator.Send(request));

        // DELETE: api/paciente/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new EliminarPacienteRequest(id));
            return NoContent();
        }
    }
}