using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeSchnecke.Models
{
    public class Wett
    {

        public int Id { get; set; }
        public string SchneckenName { get; set; }
        public int WettEinsatz { get; set; }
        public string Spieler { get; set; }

        public Wett()
        {

        }
        public Wett(string schneckenName, int wettEinsatz, string spieler)
        {
            SchneckenName = schneckenName;
            Spieler = spieler;
            WettEinsatz = wettEinsatz;
        }



    }
}
