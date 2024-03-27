using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeSchnecke.Models
{
    public class Rennschnecke
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Maximalgeschwindigkeit { get; set; }
        public int Weg { get; set; }

        public Rennschnecke()
        {

        }

        public Rennschnecke(string name, int maxSpeed)
        {
            Name = name;
            Maximalgeschwindigkeit = maxSpeed;
            Weg = 0;
        }

        public void Krieche()
        {
            Random rnd = new Random();
            Thread.Sleep(31);
            Weg += rnd.Next(1, Maximalgeschwindigkeit + 1);

        }
        public void Ausgabe()
        {
            Console.WriteLine($"Die Schnecke {Name,9} ist schon {Weg} schritte auf dem Weg");
        }
    }
}
