using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace MegaDeskApplication.Data
{
    public class MegaDeskApplicationContext : DbContext
    {
        public MegaDeskApplicationContext (DbContextOptions<MegaDeskApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
    }
}
