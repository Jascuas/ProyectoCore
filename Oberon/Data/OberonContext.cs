using Microsoft.EntityFrameworkCore;
using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Data
{
    public class OberonContext : DbContext, IOberonContext
    {
        public OberonContext(DbContextOptions options) : base(options) { }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
