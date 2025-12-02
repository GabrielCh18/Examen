using ExamenBi.Domain.Entidades;
using ExamenBi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace ExamenBi.Domain.Entities
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del torneo es obligatorio.")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public TournamentType Type { get; set; }

        public bool HasStarted { get; set; } = false;

        public ICollection<TournamentTeam> Teams { get; set; } = new List<TournamentTeam>();
    }
}
