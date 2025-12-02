using System.ComponentModel.DataAnnotations;

namespace ExamenBi
{
    public class Partido
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Fase { get; set; } = null!; // Grupos, Cuartos, Semis, Final
        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; } = null!;

        public int EquipoLocalId { get; set; }
        public Equipo EquipoLocal { get; set; } = null!;

        public int EquipoVisitanteId { get; set; }
        public Equipo EquipoVisitante { get; set; } = null!;

        public int? GolesLocal { get; set; }
        public int? GolesVisitante { get; set; }

        public ICollection<EventoPartido> Eventos { get; set; } = new List<EventoPartido>();
    }
}
