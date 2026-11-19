using clinicaconsulta.Models;
using clinicaconsulta.Repositories.Interfaces;
using clinicaconsulta.Services.Interfaces;

namespace clinicaconsulta.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _repository;

        public EspecialidadeService(IEspecialidadeRepository repository) => _repository = repository;

        public async Task<IEnumerable<Especialidade>> ListarTodasAsync() => await _repository.GetAllAsync();

        public async Task<Especialidade?> BuscarPorIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CadastrarAsync(Especialidade especialidade) => await _repository.AddAsync(especialidade);

        public async Task AtualizarAsync(Especialidade especialidade) => await _repository.UpdateAsync(especialidade);

        public async Task ExcluirAsync(int id) => await _repository.DeleteAsync(id);
    }
}