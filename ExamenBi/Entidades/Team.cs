using ExamenBi.Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
namespace ExamenBi.Domain.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es obligatorio.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Url]
        public string? LogoUrl { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();

        public ICollection<TournamentTeam> TournamentRegistrations { get; set; } = new List<TournamentTeam>();
    }
}
