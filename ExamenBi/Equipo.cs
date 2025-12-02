using System.ComponentModel.DataAnnotations;

namespace ExamenBi
{
    public class Equipo
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; } = null!;

        public ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
    }
}
