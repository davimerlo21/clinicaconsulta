using clinicaconsulta.Data;
using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaconsulta.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Consulta>> GetAllAsync() =>
            await _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente).ToListAsync();

        public async Task<Consulta?> GetByIdAsync(int id) =>
            await _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente).FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consulta = await GetByIdAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteConsultaNoHorarioAsync(int medicoId, DateTime dataHora)
        {
            return await _context.Consultas
                .AnyAsync(c => c.MedicoId == medicoId && c.DataHora == dataHora);
        }
    }
}