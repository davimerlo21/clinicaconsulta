using System.ComponentModel.DataAnnotations;

namespace clinicaconsulta.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do médico é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CRM é obrigatório.")]
        public string Crm { get; set; } = string.Empty;

        public int EspecialidadeId { get; set; }
        public Especialidade? Especialidade { get; set; }

        public ICollection<Consulta>? Consultas { get; set; }
    }
}