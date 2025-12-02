namespace ExamenBi.Domain.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; } = null!;
    }
}
