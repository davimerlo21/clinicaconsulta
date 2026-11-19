using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using clinicaconsulta.Services.Interfaces;

namespace clinicaconsulta.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository) => _repository = repository;

        public async Task<IEnumerable<Paciente>> ListarTodosAsync() => await _repository.GetAllAsync();

        public async Task<Paciente?> BuscarPorIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CadastrarAsync(Paciente paciente) => await _repository.AddAsync(paciente);

        public async Task AtualizarAsync(Paciente paciente) => await _repository.UpdateAsync(paciente);

        public async Task ExcluirAsync(int id) => await _repository.DeleteAsync(id);
    }
}