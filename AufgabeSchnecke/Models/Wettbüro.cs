using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeSchnecke.Models
{
    public class Wettbüro
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Rennen Rennen { get; set; }
        public virtual List<Wett> Wetten { get; set; }
        public int Faktor { get; set; }

        public Wettbüro()
        {



        }
        public Wettbüro(Rennen rennen, int faktor, string name)
        {

            Rennen = rennen;
            Faktor = faktor;
            Wetten = new List<Wett>();
            Name = name;
        }

        public void WetteAnnehmen(string schneckenName, int wettEinsatz, string spieler)
        {
            if (Rennen != null)
            {
                int schneckeCounter = 0;
                if (Rennen.IstRennteilnehmer(schneckenName))
                {
                    foreach (Wett eintrag in Wetten)
                    {
                        if (eintrag.SchneckenName.ToLower() == schneckenName.ToLower())
                        {
                            schneckeCounter++;
                        }
                    }
                    if (schneckeCounter < 2)
                    {
                        Wett wett = new Wett(schneckenName, wettEinsatz, spieler);
                        Wetten.Add(wett);
                    }
                    else
                    {
                        Console.WriteLine($"Könnte die Wette nicht einnehmen!");
                    }


                }
                else
                {
                    Console.WriteLine($"Es gibt keine schnecke mit den namen {schneckenName}");
                }
            }
            else
            {
                Console.WriteLine($"Es gibt kein rennen");
            }



        }

        public void PrintWette()
        {
            int wetteTabelle = Rennen.GetLänge();
            int yPosition = 10;
            string gewinner = Rennen.ErmittleGewinner();
            if (gewinner == null)
            {
                foreach (Wett eintrag in Wetten)
                {
                    Console.SetCursorPosition(wetteTabelle + 25, yPosition);
                    if (eintrag.WettEinsatz > 0)
                    {
                        Console.Write($"{eintrag.Spieler,10} hat gewettet {eintrag.WettEinsatz,3}  auf  {eintrag.SchneckenName}");
                    }
                    else
                    {
                        Console.Write($"{eintrag.Spieler,10} hat gewettet {eintrag.WettEinsatz * -1,3} gegen {eintrag.SchneckenName}");
                    }
                    yPosition += 1;
                }
            }
            else
            {
                foreach (Wett eintrag in Wetten)
                {
                    Console.SetCursorPosition(wetteTabelle + 25, yPosition);
                    if (eintrag.WettEinsatz > 0)
                    {
                        Console.Write($"{eintrag.Spieler,10} hat gewettet {eintrag.WettEinsatz,3} auf {eintrag.SchneckenName}");
                    }
                    else
                    {
                        Console.Write($"{eintrag.Spieler,10} hat gewettet {eintrag.WettEinsatz * -1,3} gegen {eintrag.SchneckenName}");
                    }
                    yPosition += 1;
                }
                Console.SetCursorPosition(wetteTabelle + 25, yPosition + 2);

                Console.Write($"Schnecke {gewinner} hat gewonnen!");

                foreach (Wett eintrag in Wetten)
                {
                    Console.SetCursorPosition(wetteTabelle + 25, yPosition + 5);

                    if (eintrag.WettEinsatz > 0)
                    {
                        if (eintrag.SchneckenName.ToLower() == gewinner.ToLower())
                        {

                            Console.Write($"Spieler {eintrag.Spieler,10} hat gewonnen {eintrag.WettEinsatz * Faktor,3}");
                        }
                        else
                        {
                            Console.Write($"Spieler {eintrag.Spieler,10} hat verloren");
                        }
                    }
                    else
                    {
                        if (eintrag.SchneckenName.ToLower() != gewinner.ToLower())
                        {

                            Console.Write($"Spieler {eintrag.Spieler,10} hat gewonnen {eintrag.WettEinsatz * Faktor * -1,3}");
                        }
                        else
                        {
                            Console.Write($"Spieler {eintrag.Spieler,10} hat verloren");
                        }
                    }
                    yPosition += 1;

                }




            }
        }
        public void RennAblauf()
        {
            Rennen.Durchführen();
        }
        public void Ausgabe()
        {
            string gewinner = Rennen.ErmittleGewinner();

            bool habenGewettet = false;
            Console.WriteLine($"Die Schnecke {gewinner} hat gewonnen");
            Console.WriteLine("-------------------------------------");
            if (gewinner != null)
            {
                foreach (Wett wett in Wetten)
                {

                    habenGewettet = true;

                    if (wett.WettEinsatz > 0)
                    {
                        if (wett.SchneckenName.ToLower() == gewinner.ToLower())
                        {

                            Console.WriteLine($"Spieler {wett.Spieler} hat gewonnen {wett.WettEinsatz * Faktor}");
                        }
                        else
                        {
                            Console.WriteLine($"Spieler {wett.Spieler} hat verloren");
                        }
                    }
                    else
                    {
                        if (wett.SchneckenName.ToLower() != gewinner.ToLower())
                        {

                            Console.WriteLine($"Spieler {wett.Spieler} hat gewonnen {wett.WettEinsatz * Faktor * -1}");
                        }
                        else
                        {
                            Console.WriteLine($"Spieler {wett.Spieler} hat verloren");
                        }
                    }


                }
            }
            else
            {
                Console.WriteLine($"Es gibt noch kein gewinner!");
            }

            if (habenGewettet == false)
            {
                Console.WriteLine($"Es gibt keine wette noch!");
            }
        }
    }
}
