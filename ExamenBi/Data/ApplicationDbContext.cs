using ExamenBi.Domain.Entities;

using Microsoft.EntityFrameworkCore;



namespace ExamenBi.Infrastructure.Data

{

    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)

        {

        }



        public DbSet<Torneo> Torneos { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<Partido> Partidos { get; set; }

        public DbSet<EventoPartido> EventosPartido { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Equipo>()

                .HasOne(e => e.Torneo)

                .WithMany(t => t.Equipos)

                .HasForeignKey(e => e.TorneoId);



            modelBuilder.Entity<Jugador>()

                .HasOne(j => j.Equipo)

                .WithMany(e => e.Jugadores)

                .HasForeignKey(j => j.EquipoId);



            modelBuilder.Entity<Partido>()

                .HasOne(p => p.Torneo)

                .WithMany(t => t.Partidos)

                .HasForeignKey(p => p.TorneoId);



            modelBuilder.Entity<Partido>()

                .HasOne(p => p.EquipoLocal)

                .WithMany()

                .HasForeignKey(p => p.EquipoLocalId)

                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Partido>()

                .HasOne(p => p.EquipoVisitante)

                .WithMany()

                .HasForeignKey(p => p.EquipoVisitanteId)

                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<EventoPartido>()

                .HasOne(e => e.Partido)

                .WithMany(p => p.Eventos)

                .HasForeignKey(e => e.PartidoId);



            modelBuilder.Entity<EventoPartido>()

                .HasOne(e => e.Jugador)

                .WithMany()

                .HasForeignKey(e => e.JugadorId);

        }

    }

}