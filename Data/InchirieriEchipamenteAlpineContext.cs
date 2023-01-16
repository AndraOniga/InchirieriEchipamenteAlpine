using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InchirieriEchipamenteAlpine.Models;

namespace InchirieriEchipamenteAlpine.Data
{
    public class InchirieriEchipamenteAlpineContext : DbContext
    {
        public InchirieriEchipamenteAlpineContext (DbContextOptions<InchirieriEchipamenteAlpineContext> options)
            : base(options)
        {
        }

        public DbSet<InchirieriEchipamenteAlpine.Models.EchipamentAlpin> EchipamentAlpin { get; set; } = default!;

        public DbSet<InchirieriEchipamenteAlpine.Models.Distribuitor> Distribuitor { get; set; }

        public DbSet<InchirieriEchipamenteAlpine.Models.Producator> Producator { get; set; }

        public DbSet<InchirieriEchipamenteAlpine.Models.Categorie> Categorie { get; set; }

        public DbSet<InchirieriEchipamenteAlpine.Models.Membru> Membru { get; set; }

        public DbSet<InchirieriEchipamenteAlpine.Models.Inchiriere> Inchiriere { get; set; }
    }
}
