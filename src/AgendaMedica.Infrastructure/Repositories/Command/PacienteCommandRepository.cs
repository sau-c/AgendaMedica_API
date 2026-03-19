using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.CommandRepositories;
using AgendaMedica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infrastructure.Repositories.Command
{
    public class PacienteCommandRepository : IPacienteCommandRepository
    {
        private readonly AppDbContext _context;
        public PacienteCommandRepository(AppDbContext context)
            => _context = context;

        public async Task AgregarAsync(Paciente paciente)
        { 
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }
        
        public async Task ActualizarAsync(Paciente paciente)
        {
            // Caso 1: entidad trackeada => no hace nada
            var entry = _context.Entry(paciente);

            if (entry.State == EntityState.Detached)
            {
                // Caso 2: entidad NO trackeada
                _context.Pacientes.Attach(paciente);
                entry.State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> EliminarAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
