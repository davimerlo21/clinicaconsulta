using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using clinicaconsulta.Services.Interfaces;

namespace clinicaconsulta.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<IEnumerable<Consulta>> ListarTodasAsync() => await _consultaRepository.GetAllAsync();

        public async Task<Consulta?> BuscarPorIdAsync(int id) => await _consultaRepository.GetByIdAsync(id);

        public async Task<(bool Sucesso, string Mensagem)> AgendarConsultaAsync(Consulta consulta)
        {
            // Regra de negócio: Verificar se já existe consulta para o mesmo médico na mesma data e hora
            bool conflito = await _consultaRepository.ExisteConsultaNoHorarioAsync(consulta.MedicoId, consulta.DataHora);

            if (conflito)
            {
                return (false, "O médico já possui uma consulta agendada para este dia e horário.");
            }

            await _consultaRepository.AddAsync(consulta);
            return (true, "Consulta agendada com sucesso!");
        }

        public async Task ExcluirAsync(int id) => await _consultaRepository.DeleteAsync(id);
    }
}