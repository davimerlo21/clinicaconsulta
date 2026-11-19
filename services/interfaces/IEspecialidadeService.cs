using clinicaconsulta.Models;

namespace clinicaconsulta.Services.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<Especialidade>> ListarTodasAsync();
        Task<Especialidade?> BuscarPorIdAsync(int id);
        Task CadastrarAsync(Especialidade especialidade);
        Task AtualizarAsync(Especialidade especialidade);
        Task ExcluirAsync(int id);
    }
}