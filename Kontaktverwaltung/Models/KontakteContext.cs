using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontaktverwaltung.Models
{
    internal class KontakteContext : DbContext
    {

        public DbSet<Kontakt> Kontakt { get; set; }

        public KontakteContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=KontaktverwaltungDB;Trusted_Connection=True;Encrypt=False");
        }
    }
}
