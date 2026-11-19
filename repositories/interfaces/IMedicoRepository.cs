using clinicaconsulta.Models;

namespace clinicaconsulta.Repositories.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico?> GetByIdAsync(int id);
        Task AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}