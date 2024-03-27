using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeSchnecke.Models
{
    public class SchneckerennenContext : DbContext
    {
        public DbSet<Wettbüro> WettBüro { get; set; }

        public SchneckerennenContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchneckenRennenDB;Trusted_Connection=True;Encrypt=False");
        }

    }
}
