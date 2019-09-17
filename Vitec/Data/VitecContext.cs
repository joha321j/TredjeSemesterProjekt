using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vitec.Models
{
    public class VitecContext : DbContext
    {
        public VitecContext (DbContextOptions<VitecContext> options)
            : base(options)
        {
        }

        public DbSet<Vitec.Models.User> User { get; set; }
    }
}
