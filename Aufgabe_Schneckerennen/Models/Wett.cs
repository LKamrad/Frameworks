using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Schneckerennen.Models
{
    public class Wett
    {
        private string _schneckenName;
        private int _wettEinsatz;
        private string _spieler;

        public Wett(string schneckenName, int wettEinsatz, string spieler)
        {
            _schneckenName = schneckenName;
            _spieler = spieler;
            _wettEinsatz = wettEinsatz;
        }
        public string GetSchneckenName() { return _schneckenName; }
        public int GetWettEinsatz() { return _wettEinsatz; }
        public string GetSpieler() { return _spieler; }


    }
}
