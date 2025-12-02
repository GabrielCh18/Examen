using ExamenBi.Domain.Entities;
using ExamenBi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenBi.Domain.Entidades
{
    public class MatchEvent
    {
        [Key]
        public int Id { get; set; }

        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public Match? Match { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player? Player { get; set; }

        [Required]
        public MatchEventType EventType { get; set; } 

        [Range(0, 130)]
        public int Minute { get; set; }
    }
}
