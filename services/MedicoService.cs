using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using clinicaconsulta.Services.Interfaces;

namespace clinicaconsulta.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository) => _repository = repository;

        public async Task<IEnumerable<Medico>> ListarTodosAsync() => await _repository.GetAllAsync();

        public async Task<Medico?> BuscarPorIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CadastrarAsync(Medico medico) => await _repository.AddAsync(medico);

        public async Task AtualizarAsync(Medico medico) => await _repository.UpdateAsync(medico);

        public async Task ExcluirAsync(int id) => await _repository.DeleteAsync(id);
    }
}