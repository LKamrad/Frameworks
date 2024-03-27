using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Schneckerennen.Models
{
    public class Rennen
    {
        private string _name;
        private int _maxAnzahlTeilnehmendenSchnecken;
        private List<Rennschnecke> _teilnehmendenSchnecken;
        private int _länge;

        public Rennen(string name, int max, int länge)
        {
            _name = name;
            _maxAnzahlTeilnehmendenSchnecken = max;
            _länge = länge;
            _teilnehmendenSchnecken = new List<Rennschnecke>();
        }
        public void AddRennschnecke(Rennschnecke neueSchnecke)
        {
            int counter = 0;
            if (_teilnehmendenSchnecken != null)
            {
                foreach (Rennschnecke rns in _teilnehmendenSchnecken)
                {
                    counter++;
                }
            }
            if (counter < _maxAnzahlTeilnehmendenSchnecken)
            {
                _teilnehmendenSchnecken.Add(neueSchnecke);
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
                Console.WriteLine($"Rennen {_name} läuft die länge ist {_länge}:");
                foreach (Rennschnecke rns in _teilnehmendenSchnecken)
                {
                    rns.Ausgabe();
                }
            }
            else
            {
                Console.WriteLine($"Rennen {_name} ist abgeschlossen der/die Gewinner/in ist {gewinner}");
            }

        }
        public string ErmittleGewinner()
        {
            string gewinner = null;
            foreach (Rennschnecke rns in _teilnehmendenSchnecken)
            {
                if (rns.GetWeg() >= _länge)
                {
                    gewinner = rns.GetName();
                    break;
                }
            }
            return gewinner;
        }
        public void LasseSchneckenKriechen()
        {

            // Get the elapsed time as a TimeSpan value.



            foreach (Rennschnecke rns in _teilnehmendenSchnecken)
            {
                rns.Krieche();
            }
        }
        public void PrintFinishLine()
        {
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(_länge + 20, i);
                Console.Write("|");
            }
        }
        public int GetLänge()
        {
            return _länge;
        }
        public void PrintRaceAnimation1()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int yPosition = 0;
            PrintFinishLine();
            foreach (Rennschnecke rns in _teilnehmendenSchnecken)
            {
                Snail1(rns.GetWeg(), yPosition);
                Console.Write(rns.GetName());
                yPosition += 7;
            }

        }
        public void PrintRaceAnimation2()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int yPosition = 0;
            PrintFinishLine();
            foreach (Rennschnecke rns in _teilnehmendenSchnecken)
            {
                Snail2(rns.GetWeg(), yPosition);
                Console.Write(rns.GetName());
                yPosition += 7;
            }

        }
        public void Durchführen()
        {
            if (_teilnehmendenSchnecken != null)
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
            foreach (Rennschnecke rns in _teilnehmendenSchnecken)
            {
                if (rns.GetName().ToLower() == schneckenName.ToLower())
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
