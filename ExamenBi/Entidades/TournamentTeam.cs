using ExamenBi.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenBi.Domain.Entidades
{
    public class TournamentTeam
    {
        public int TournamentId { get; set; }
        public Tournament? Tournament { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }

        [MaxLength(1)]
        public string? GroupName { get; set; }
    }
}
