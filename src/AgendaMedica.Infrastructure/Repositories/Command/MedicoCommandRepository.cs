using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.CommandRepositories;
using AgendaMedica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Infrastructure.Repositories.Command
{
    public class MedicoCommandRepository : IMedicoCommandRepository
    {
        private readonly AppDbContext _context;
        public MedicoCommandRepository(AppDbContext context)
            => _context = context;

        public async Task AgregarAsync(Medico medico)
        { 
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
        } 
        
        public async Task ActualizarAsync(Medico medico)
        {
            // Caso 1: entidad trackeada => no hace nada
            var entry = _context.Entry(medico);

            if (entry.State == EntityState.Detached)
            {
                // Caso 2: entidad NO trackeada
                _context.Medicos.Attach(medico);
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
