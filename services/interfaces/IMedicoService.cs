using clinicaconsulta.Models;

namespace clinicaconsulta.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<Medico>> ListarTodosAsync();
        Task<Medico?> BuscarPorIdAsync(int id);
        Task CadastrarAsync(Medico medico);
        Task AtualizarAsync(Medico medico);
        Task ExcluirAsync(int id);
    }
}