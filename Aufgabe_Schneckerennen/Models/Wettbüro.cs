using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Schneckerennen.Models
{
    public class Wettbüro
    {
        private Rennen _rennen;
        private List<Wett> _wetten;
        private readonly int _faktor;

        public Wettbüro(Rennen rennen, int faktor)
        {

            _rennen = rennen;
            _faktor = faktor;
            _wetten = new List<Wett>();

        }

        public void WetteAnnehmen(string schneckenName, int wettEinsatz, string spieler)
        {
            if (_rennen != null)
            {
                int schneckeCounter = 0;
                if (_rennen.IstRennteilnehmer(schneckenName))
                {
                    foreach (Wett eintrag in _wetten)
                    {
                        if (eintrag.GetSchneckenName().ToLower() == schneckenName.ToLower())
                        {
                            schneckeCounter++;
                        }
                    }
                    if (schneckeCounter < 2)
                    {
                        Wett wett = new Wett(schneckenName, wettEinsatz, spieler);
                        _wetten.Add(wett);
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
            int wetteTabelle = _rennen.GetLänge();
            int yPosition = 10;
            string gewinner = _rennen.ErmittleGewinner();
            if (gewinner == null)
            {
                foreach (Wett eintrag in _wetten)
                {
                    Console.SetCursorPosition(wetteTabelle + 25, yPosition);
                    if (eintrag.GetWettEinsatz() > 0)
                    {
                        Console.Write($"{eintrag.GetSpieler(),10} hat gewettet {eintrag.GetWettEinsatz(),3}  auf  {eintrag.GetSchneckenName()}");
                    }
                    else
                    {
                        Console.Write($"{eintrag.GetSpieler(),10} hat gewettet {eintrag.GetWettEinsatz() * -1,3} gegen {eintrag.GetSchneckenName()}");
                    }
                    yPosition += 1;
                }
            }
            else
            {
                foreach (Wett eintrag in _wetten)
                {
                    Console.SetCursorPosition(wetteTabelle + 25, yPosition);
                    if (eintrag.GetWettEinsatz() > 0)
                    {
                        Console.Write($"{eintrag.GetSpieler(),10} hat gewettet {eintrag.GetWettEinsatz(),3} auf {eintrag.GetSchneckenName()}");
                    }
                    else
                    {
                        Console.Write($"{eintrag.GetSpieler(),10} hat gewettet {eintrag.GetWettEinsatz() * -1,3} gegen {eintrag.GetSchneckenName()}");
                    }
                    yPosition += 1;
                }
                Console.SetCursorPosition(wetteTabelle + 25, yPosition + 2);

                Console.Write($"Schnecke {gewinner} hat gewonnen!");

                foreach (Wett eintrag in _wetten)
                {
                    Console.SetCursorPosition(wetteTabelle + 25, yPosition + 5);

                    if (eintrag.GetWettEinsatz() > 0)
                    {
                        if (eintrag.GetSchneckenName().ToLower() == gewinner.ToLower())
                        {

                            Console.Write($"Spieler {eintrag.GetSpieler(),10} hat gewonnen {eintrag.GetWettEinsatz() * _faktor,3}");
                        }
                        else
                        {
                            Console.Write($"Spieler {eintrag.GetSpieler(),10} hat verloren");
                        }
                    }
                    else
                    {
                        if (eintrag.GetSchneckenName().ToLower() != gewinner.ToLower())
                        {

                            Console.Write($"Spieler {eintrag.GetSpieler(),10} hat gewonnen {eintrag.GetWettEinsatz() * _faktor * -1,3}");
                        }
                        else
                        {
                            Console.Write($"Spieler {eintrag.GetSpieler(),10} hat verloren");
                        }
                    }
                    yPosition += 1;

                }




            }
        }
        public void RennAblauf()
        {
            _rennen.Durchführen();
        }
        public void Ausgabe()
        {
            string gewinner = _rennen.ErmittleGewinner();

            bool habenGewettet = false;
            Console.WriteLine($"Die Schnecke {gewinner} hat gewonnen");
            Console.WriteLine("-------------------------------------");
            if (gewinner != null)
            {
                foreach (Wett wett in _wetten)
                {

                    habenGewettet = true;

                    if (wett.GetWettEinsatz() > 0)
                    {
                        if (wett.GetSchneckenName().ToLower() == gewinner.ToLower())
                        {

                            Console.WriteLine($"Spieler {wett.GetSpieler()} hat gewonnen {wett.GetWettEinsatz() * _faktor}");
                        }
                        else
                        {
                            Console.WriteLine($"Spieler {wett.GetSpieler()} hat verloren");
                        }
                    }
                    else
                    {
                        if (wett.GetSchneckenName().ToLower() != gewinner.ToLower())
                        {

                            Console.WriteLine($"Spieler {wett.GetSpieler()} hat gewonnen {wett.GetWettEinsatz() * _faktor * -1}");
                        }
                        else
                        {
                            Console.WriteLine($"Spieler {wett.GetSpieler()} hat verloren");
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
