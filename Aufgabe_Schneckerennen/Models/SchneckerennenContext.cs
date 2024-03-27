using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Schneckerennen.Models
{
    public class SchneckerennenContext : DbContext
    {
        //public DbSet<Wettbüro> buros { get; set; }

        public SchneckerennenContext()
        {
            this.Database.EnsureCreated();
        }

        public void SavetoDatabase()
        {

            this.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AufgabeWarenlagerDB;Trusted_Connection=True;Encrypt=False");
        }

    }
}
