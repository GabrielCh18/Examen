using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenBi.Emun;
namespace ExamenBi.Data

{
    public class LigaApiContext : DbContext
    {
        public LigaApiContext (DbContextOptions<LigaApiContext> options)
            : base(options)
        {
        }
        public DbSet<ExamenBi.Goal> Goal { get; set; } = default!;
        public DbSet<ExamenBi.Card> Card { get; set; } = default!;
        public DbSet<ExamenBi.Emun.TipoTorneo> TipoTorneo { get; set; } = default!;
    }
}
