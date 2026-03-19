using AgendaMedica.Application.Features.Pacientes.DTO;
using AgendaMedica.Application.QueryRepositories;
using AgendaMedica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infrastructure.Repositories.Query
{
    public class PacienteQueryRepository : IPacienteQueryRepository
    {
        private readonly AppDbContext _context;

        public PacienteQueryRepository(AppDbContext context)
            => _context = context;

        public async Task<PacienteDTO?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Pacientes
                .AsNoTracking()
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new PacienteDTO(
                    p.Id,
                    p.Nombre.Valor,
                    p.ApellidoPaterno.Valor,
                    p.ApellidoMaterno.Valor,
                    p.FechaNacimiento,
                    p.CorreoElectronico.Valor
                ))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PacienteDTO>> ListarAsync()
        {
            return await _context.Pacientes
                .AsNoTracking()
                .Where(p => !p.IsDeleted)
                .Select(p => new PacienteDTO(
                    p.Id,
                    p.Nombre.Valor,
                    p.ApellidoPaterno.Valor,
                    p.ApellidoMaterno.Valor,
                    p.FechaNacimiento,
                    p.CorreoElectronico.Valor
                ))
                .ToListAsync();
        }
    }
}