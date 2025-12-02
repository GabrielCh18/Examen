using System.ComponentModel.DataAnnotations;

namespace ExamenBi
{
    public class Jugador
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; } = null!;
        public int Goles { get; set; } = 0;
    }
}
