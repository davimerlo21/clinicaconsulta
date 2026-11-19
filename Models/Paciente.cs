using System.ComponentModel.DataAnnotations;

namespace clinicaconsulta.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        public ICollection<Consulta>? Consultas { get; set; }
    }
}