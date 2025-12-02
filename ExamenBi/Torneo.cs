using System.ComponentModel.DataAnnotations;

namespace ExamenBi
{
    public class Torneo
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Tipo { get; set; } = null!; // Liga, Copa, Mixto

        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
        public ICollection<Partido> Partidos { get; set; } = new List<Partido>();
    }
}
