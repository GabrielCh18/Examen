using ExamenBi.Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenBi.Domain.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Range(1, 99, ErrorMessage = "El dorsal debe estar entre 1 y 99.")]
        public int Dorsal { get; set; }

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team? Team { get; set; }

        public ICollection<MatchEvent> Events { get; set; } = new List<MatchEvent>();
    }
}
