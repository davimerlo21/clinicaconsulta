using System.ComponentModel.DataAnnotations;

namespace clinicaconsulta.Models
{
    public class Especialidade
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da especialidade é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Medico>? Medicos { get; set; }
    }
}