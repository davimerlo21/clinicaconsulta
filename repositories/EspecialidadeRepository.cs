using clinicaconsulta.Data;
using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaconsulta.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadeRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Especialidade>> GetAllAsync() => await _context.Especialidades.ToListAsync();

        public async Task<Especialidade?> GetByIdAsync(int id) => await _context.Especialidades.FindAsync(id);

        public async Task AddAsync(Especialidade especialidade)
        {
            _context.Especialidades.Add(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Especialidade especialidade)
        {
            _context.Especialidades.Update(especialidade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var esp = await GetByIdAsync(id);
            if (esp != null)
            {
                _context.Especialidades.Remove(esp);
                await _context.SaveChangesAsync();
            }
        }
    }
}