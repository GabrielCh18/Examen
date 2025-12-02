using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
namespace ExamenBi.Data
=======
using ExamenBi.Domain.Enums;
>>>>>>> 397a57b237533a602c8d4105b1ca0e8f553db794

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
