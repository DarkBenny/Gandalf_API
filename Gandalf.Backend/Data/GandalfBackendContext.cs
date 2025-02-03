using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gandalf.Backend.Models;

namespace Gandalf.Backend.Data
{
    public class GandalfBackendContext : DbContext
    {
        public GandalfBackendContext (DbContextOptions<GandalfBackendContext> options)
            : base(options)
        {
        }

        public DbSet<Gandalf.Backend.Models.Category> Category { get; set; } = default!;
        public DbSet<Gandalf.Backend.Models.Product> Product{ get; set; } = default!;
    }
}
