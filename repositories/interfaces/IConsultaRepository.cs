using clinicaconsulta.Models;

namespace clinicaconsulta.Repositories.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task<Consulta?> GetByIdAsync(int id);
        Task AddAsync(Consulta consulta);
        Task DeleteAsync(int id);
        Task<bool> ExisteConsultaNoHorarioAsync(int medicoId, DateTime dataHora);
    }
}