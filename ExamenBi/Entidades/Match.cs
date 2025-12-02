using ExamenBi.Domain.Entities;
using ExamenBi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenBi.Domain.Entidades
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public int TournamentId { get; set; }
        [ForeignKey("TournamentId")]
        public Tournament? Tournament { get; set; }

        public int HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public Team? HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        [ForeignKey("AwayTeamId")]
        public Team? AwayTeam { get; set; }

        public int HomeScore { get; set; } = 0;
        public int AwayScore { get; set; } = 0;

        public int? HomePenalties { get; set; }
        public int? AwayPenalties { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

        public TournamentStage Stage { get; set; }

        public int RoundNumber { get; set; }

       
        public ICollection<MatchEvent> Events { get; set; } = new List<MatchEvent>();

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
