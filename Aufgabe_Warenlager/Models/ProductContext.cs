using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Warenlager.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Artikel> Artikeln { get; set; }

        public ProductContext()
        {
            this.Database.EnsureCreated();
        }

        public void SavetoDatabase()
        {
            StreamReader sr = new StreamReader(@"c:\Filestream\Lager.txt");

            while (sr.EndOfStream == false)
            {
                try
                {
                    string[] arr = sr.ReadLine().Split(';');
                    Artikel art = new Artikel()
                    {
                        Id = int.Parse(arr[0]),
                        Bezeichnung = arr[1],
                        Istbestand = int.Parse(arr[2]),
                        Höchstbestand = int.Parse(arr[3]),
                        Preis = double.Parse(arr[4]),
                        VerbrauchProTag = int.Parse(arr[5]),
                        BestelldauerInTagen = int.Parse(arr[6])
                    };
                    Artikeln.Add(art);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            sr.Close();
            this.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
 
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AufgabeWarenlagerDB;Trusted_Connection=True;Encrypt=False");
        }

        public override string ToString()
        {
            string temp = "";
            foreach (var item in Artikeln)
            {
                temp += item;
                temp += "\n";
            }

            return temp;
        }
    }
}
