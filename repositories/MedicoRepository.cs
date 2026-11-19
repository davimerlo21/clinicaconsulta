using clinicaconsulta.Data;
using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaconsulta.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Medico>> GetAllAsync() => await _context.Medicos.Include(m => m.Especialidade).ToListAsync();

        public async Task<Medico?> GetByIdAsync(int id) => await _context.Medicos.Include(m => m.Especialidade).FirstOrDefaultAsync(m => m.Id == id);

        public async Task AddAsync(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medico medico)
        {
            _context.Medicos.Update(medico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await GetByIdAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();
            }
        }
    }
}