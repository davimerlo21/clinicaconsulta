using System.ComponentModel.DataAnnotations;

namespace clinicaconsulta.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias.")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Selecione o médico.")]
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Selecione o paciente.")]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}