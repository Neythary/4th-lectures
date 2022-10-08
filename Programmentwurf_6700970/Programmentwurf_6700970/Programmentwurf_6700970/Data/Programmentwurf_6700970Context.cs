using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_6700970.Models;

namespace Programmentwurf_6700970.Data
{
    public class Programmentwurf_6700970Context : DbContext
    {
        public Programmentwurf_6700970Context (DbContextOptions<Programmentwurf_6700970Context> options)
            : base(options)
        {
        }

        public DbSet<Programmentwurf_6700970.Models.BuecherModel> BuecherModel { get; set; } = default!;
    }
}
