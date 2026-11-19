using clinicaconsulta.Models;

namespace clinicaconsulta.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<IEnumerable<Consulta>> ListarTodasAsync();
        Task<Consulta?> BuscarPorIdAsync(int id);
        Task<(bool Sucesso, string Mensagem)> AgendarConsultaAsync(Consulta consulta);
        Task ExcluirAsync(int id);
    }
}