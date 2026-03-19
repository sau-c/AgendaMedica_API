using AgendaMedica.Application.Features.Medicos.DTO;
using AgendaMedica.Application.QueryRepositories;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.ValueObjects;
using AgendaMedica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infrastructure.Repositories.Query
{
    public class MedicoQueryRepository : IMedicoQueryRepository
    {
        private readonly AppDbContext _context;

        public MedicoQueryRepository(AppDbContext context)
            => _context = context;

        public async Task<MedicoDTO?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Medicos
                .AsNoTracking()
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new MedicoDTO(
                    p.Id,
                    p.Nombre.Valor,
                    p.ApellidoPaterno.Valor,
                    p.ApellidoMaterno.Valor,
                    p.Especialidades
                        .Select(e => e.Nombre.Valor)
                        .ToList(),
                    p.HorariosConsulta
                        .Select(e => e.DiaSemana.ToString())
                        .ToList()
                )).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MedicoDTO>> ListarAsync()
        {
            return await _context.Medicos
                .AsNoTracking()
                .Where(m => !m.IsDeleted)
                .Select(m => new MedicoDTO(
                    m.Id,
                    m.Nombre.Valor,
                    m.ApellidoPaterno.Valor,
                    m.ApellidoMaterno.Valor,
                    m.Especialidades
                        .Select(e => e.Nombre.Valor)
                        .ToList(),
                    m.HorariosConsulta
                        .Select(e => e.DiaSemana.ToString())
                        .ToList()
                ))
                .ToListAsync();
        }
    }
}