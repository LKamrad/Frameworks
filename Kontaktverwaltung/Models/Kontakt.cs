using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontaktverwaltung.Models
{
    public class Kontakt
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geschlecht { get; set; }
        public string Telefonnummer { get; set; }

        public string EMail { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }

        public override string ToString()
        {

            if (Id == 0)
            {
                return $"Vorname: \t{Vorname,10}\n" +
                    $"Nachname: \t{Nachname,10}\n" +
                    $"Geschlecht: \t{Geschlecht,10}\n" +
                    $"Telefonnummer: \t{Telefonnummer,10}\n" +
                    $"EMail: \t{EMail,10}\n" +
                    $"PLZ:      \t{PLZ,10}\n" +
                    $"Ort:      \t{Ort,10}";
            }
            return $"Id:       \t{Id,10}\n" +
                $"Vorname: \t{Vorname,10}\n" +
                $"Nachname: \t{Nachname,10}\n" +
                $"Geschlecht: \t{Geschlecht,10}\n" +
                $"Telefonnummer: \t{Telefonnummer,10}\n" +
                $"EMail: \t{EMail,10}\n" +
                $"PLZ:      \t{PLZ,10}\n" +
                $"Ort:      \t{Ort,10}";
        }
    }

}
