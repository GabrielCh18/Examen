using ExamenBi.Domain.Enums;

namespace ExamenBi.Domain.Entities
{
    public class EventoPartido
    {
        public int Id { get; set; }

        public int PartidoId { get; set; }
        public Partido Partido { get; set; } = null!;

        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; } = null!;

        public TipoEvento Evento { get; set; }
    }
}
