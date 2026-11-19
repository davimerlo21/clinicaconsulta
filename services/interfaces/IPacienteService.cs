using clinicaconsulta.Models;

namespace clinicaconsulta.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> ListarTodosAsync();
        Task<Paciente?> BuscarPorIdAsync(int id);
        Task CadastrarAsync(Paciente paciente);
        Task AtualizarAsync(Paciente paciente);
        Task ExcluirAsync(int id);
    }
}