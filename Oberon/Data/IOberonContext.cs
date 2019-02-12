using Microsoft.EntityFrameworkCore;
using Oberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.Data
{
    public interface IOberonContext
    {
        DbSet<Usuario> Usuario { get; set; }
        int SaveChanges();
    }
}
