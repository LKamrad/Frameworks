using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Schneckerennen.Models
{
    public class Rennschnecke
    {
        private string _name;
        private int _maximalgeschwindigkeit;
        private int _weg;

        public Rennschnecke(string name, int maxSpeed)
        {
            _name = name;
            _maximalgeschwindigkeit = maxSpeed;
            _weg = 0;
        }
        public string GetName() { return _name; }
        public int GetWeg() { return _weg; }

        public void Krieche()
        {
            Random rnd = new Random();
            Thread.Sleep(31);
            _weg += rnd.Next(1, _maximalgeschwindigkeit + 1);

        }
        public void Ausgabe()
        {
            Console.WriteLine($"Die Schnecke {_name,9} ist schon {_weg} schritte auf dem Weg");
        }
    }
}
