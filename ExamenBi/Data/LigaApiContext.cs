using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ExamenBi.Data

{
    public class LigaApiContext : DbContext
    {
        public LigaApiContext (DbContextOptions<LigaApiContext> options)
            : base(options)
        {
        }
    }
}
