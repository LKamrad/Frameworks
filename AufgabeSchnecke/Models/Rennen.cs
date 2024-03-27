using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeSchnecke.Models
{
    public class Rennen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxAnzahlTeilnehmendenSchnecken { get; set; }
        public virtual List<Rennschnecke> Schnecken { get; set; }
        public int Länge { get; set; }
        public Rennen()
        {

        }
        public Rennen(string name, int max, int länge)
        {
            Name = name;
            MaxAnzahlTeilnehmendenSchnecken = max;
            Länge = länge;
            Schnecken = new List<Rennschnecke>();
        }
        public void AddRennschnecke(Rennschnecke neueSchnecke)
        {
            int counter = 0;
            if (Schnecken != null)
            {
                foreach (Rennschnecke rns in Schnecken)
                {
                    counter++;
                }
            }
            if (counter < MaxAnzahlTeilnehmendenSchnecken)
            {
                Schnecken.Add(neueSchnecke);
            }
            else
            {
                Console.WriteLine($"Maximal anzahl von Teilnehmern erreicht");
            }

        }
        public void Ausgabe()
        {
            string gewinner = ErmittleGewinner();
            if (gewinner == null)
            {
                Console.WriteLine($"Rennen {Name} läuft die länge ist {Länge}:");
                foreach (Rennschnecke rns in Schnecken)
                {
                    rns.Ausgabe();
                }
            }
            else
            {
                Console.WriteLine($"Rennen {Name} ist abgeschlossen der/die Gewinner/in ist {gewinner}");
            }

        }
        public string ErmittleGewinner()
        {
            string gewinner = null;
            foreach (Rennschnecke rns in Schnecken)
            {
                if (rns.Weg >= Länge)
                {
                    gewinner = rns.Name;
                    break;
                }
            }
            return gewinner;
        }
        public void LasseSchneckenKriechen()
        {

            // Get the elapsed time as a TimeSpan value.



            foreach (Rennschnecke rns in Schnecken)
            {
                rns.Krieche();
            }
        }
        public void PrintFinishLine()
        {
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(Länge + 20, i);
                Console.Write("|");
            }
        }
        public int GetLänge()
        {
            return Länge;
        }
        public void PrintRaceAnimation1()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int yPosition = 0;
            PrintFinishLine();
            foreach (Rennschnecke rns in Schnecken)
            {
                Snail1(rns.Weg, yPosition);
                Console.Write(rns.Name);
                yPosition += 7;
            }

        }
        public void PrintRaceAnimation2()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int yPosition = 0;
            PrintFinishLine();
            foreach (Rennschnecke rns in Schnecken)
            {
                Snail2(rns.Weg, yPosition);
                Console.Write(rns.Name);
                yPosition += 7;
            }

        }
        public void Durchführen()
        {
            if (Schnecken != null)
            {
                while (ErmittleGewinner() == null)
                {
                    LasseSchneckenKriechen();
                }
            }
            else
            {
                Console.WriteLine("Es gibt keine Teilnehmern!!");
            }

        }
        public bool IstRennteilnehmer(string schneckenName)
        {
            bool isTeilnehmer = false;
            foreach (Rennschnecke rns in Schnecken)
            {
                if (rns.Name.ToLower() == schneckenName.ToLower())
                {
                    isTeilnehmer = true;
                }
            }

            return isTeilnehmer;
        }

        public void Snail1(int x, int y)
        {
            Console.SetCursorPosition(x, y + 1);
            Console.Write("    .----.   @   @");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("   / .-\"-.`.  \\v/");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("   | | '\\ \\ \\_/ )");
            Console.SetCursorPosition(x, y + 4);
            Console.Write(" ,-\\ `-.' /.'  /");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("'---`----'----'");
            Console.SetCursorPosition(x, y + 6);
        }
        public void Snail2(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("         __,._");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("        /  _  \\");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("       |  6 \\  \\  oo");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("        \\___/ .|__||");
            Console.SetCursorPosition(x, y + 4);
            Console.Write(" __,..=\"^  . , \"  , \\");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("<.__________________/");
            Console.SetCursorPosition(x, y + 6);
        }


    }
}
