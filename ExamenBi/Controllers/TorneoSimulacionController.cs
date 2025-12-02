using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenBi.Infrastructure.Data;
using ExamenBi;

namespace ExamenBi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneoSimulacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TorneoSimulacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("EjecutarPrueba")]
        public async Task<IActionResult> EjecutarPrueba()
        {
            var resumen = new List<string>();

            // 1. Crear torneo
            var torneo = new Torneo
            {
                Nombre = "Copa Primavera 2024",
                Tipo = "Mixto"
            };
            _context.Torneos.Add(torneo);
            await _context.SaveChangesAsync();
            resumen.Add("✔ Torneo creado: Copa Primavera 2024 (Mixto)");

            // 2. Crear 16 equipos
            for (int i = 1; i <= 16; i++)
            {
                _context.Equipos.Add(new Equipo
                {
                    Nombre = $"Equipo {i}",
                    TorneoId = torneo.Id
                });
            }
            await _context.SaveChangesAsync();
            resumen.Add("✔ 16 equipos inscritos");

            // Obtener equipos
            var equipos = await _context.Equipos
                .Where(e => e.TorneoId == torneo.Id)
                .ToListAsync();

            // 3. Generar calendario automático (fase de grupos)
            var partidos = new List<Partido>();
            for (int i = 0; i < equipos.Count; i += 2)
            {
                partidos.Add(new Partido
                {
                    TorneoId = torneo.Id,
                    EquipoLocalId = equipos[i].Id,
                    EquipoVisitanteId = equipos[i + 1].Id,
                    Fase = "Grupos"
                });
            }
            _context.Partidos.AddRange(partidos);
            await _context.SaveChangesAsync();

            resumen.Add("✔ Calendario de fase de grupos generado");

            // 4. Registrar resultados
            var random = new Random();
            foreach (var p in partidos)
            {
                p.GolesLocal = random.Next(0, 5);
                p.GolesVisitante = random.Next(0, 5);
            }
            await _context.SaveChangesAsync();

            resumen.Add("✔ Resultados de todos los partidos registrados");

            // 5. Clasificar top 8 equipos (aleatorio simplificado)
            var clasificados = equipos
                .OrderBy(x => random.Next())
                .Take(8)
                .ToList();

            resumen.Add("✔ 8 equipos clasificados a eliminación directa");

            // 6. Crear y registrar resultados de cuartos, semis, final
            var fases = new[] { "Cuartos", "Semifinal", "Final" };

            List<Equipo> vivos = clasificados;

            foreach (var fase in fases)
            {
                var nuevosPartidos = new List<Partido>();
                var ganadores = new List<Equipo>();

                for (int i = 0; i < vivos.Count; i += 2)
                {
                    var p = new Partido
                    {
                        TorneoId = torneo.Id,
                        EquipoLocalId = vivos[i].Id,
                        EquipoVisitanteId = vivos[i + 1].Id,
                        Fase = fase,
                        GolesLocal = random.Next(0, 5),
                        GolesVisitante = random.Next(0, 5)
                    };

                    nuevosPartidos.Add(p);

                    // determinar ganador
                    if (p.GolesLocal >= p.GolesVisitante)
                        ganadores.Add(vivos[i]);
                    else
                        ganadores.Add(vivos[i + 1]);
                }

                _context.Partidos.AddRange(nuevosPartidos);
                await _context.SaveChangesAsync();

                resumen.Add($"✔ Resultados registrados para fase: {fase}");

                vivos = ganadores;
            }

            // 7. Campeón
            var campeon = vivos.First();
            resumen.Add($"🏆 CAMPEÓN: {campeon.Nombre}");

            // 8. Tabla de goleadores (simplificado)
            var goleadores = await _context.Jugadores
                .OrderByDescending(j => j.Goles)
                .Take(5)
                .Select(j => new { j.Nombre, j.Goles })
                .ToListAsync();

            resumen.Add("✔ Tabla de goleadores generada");

            // 9. Historial entre dos equipos
            var eq1 = equipos[0];
            var eq2 = equipos[1];

            var historial = await _context.Partidos
                .Where(p =>
                    (p.EquipoLocalId == eq1.Id && p.EquipoVisitanteId == eq2.Id) ||
                    (p.EquipoLocalId == eq2.Id && p.EquipoVisitanteId == eq1.Id))
                .ToListAsync();

            resumen.Add($"✔ Historial entre {eq1.Nombre} y {eq2.Nombre}: {historial.Count} partidos");

            // RESPUESTA FINAL
            return Ok(new
            {
                Mensaje = "Simulación completada",
                Resumen = resumen,
                Campeon = campeon.Nombre,
                Goleadores = goleadores,
                Historial = historial
            });
        }
    }
}
