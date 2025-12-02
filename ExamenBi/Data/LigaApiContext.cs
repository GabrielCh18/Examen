using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenBi.Domain.Enums;

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
