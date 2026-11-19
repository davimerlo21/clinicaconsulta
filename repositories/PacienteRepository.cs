using clinicaconsulta.Data;
using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaconsulta.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Paciente>> GetAllAsync() => await _context.Pacientes.ToListAsync();

        public async Task<Paciente?> GetByIdAsync(int id) => await _context.Pacientes.FindAsync(id);

        public async Task AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await GetByIdAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}