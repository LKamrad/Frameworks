using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Warenlager.Models
{
    public class Artikel
    {
 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int Istbestand { get; set; }
        public int Höchstbestand { get; set; }
        public double Preis { get; set; }
        public int VerbrauchProTag { get; set; }
        public int BestelldauerInTagen { get; set; }

        [NotMapped]
        public int Meldebestand { get { return VerbrauchProTag + BestelldauerInTagen + 2; } }
        [NotMapped]
        public int Bestellvorschlag { get { return Istbestand - Meldebestand;  } }

        public override string ToString()
        {
            return $"Artikelnummer:        \t{Id,10}\n" +
                $"Bezeichnung:         \t{Bezeichnung,10}\n" +
                $"Istbestand:       \t{Istbestand,10}\n" +
                $"Höchstbestand:        \t{Höchstbestand,10}\n" +
                $"Preis:           \t{Preis,10}\n" +
                $"Verbrauch pro Tag: \t{VerbrauchProTag,10}\n" +
                $"Bestelldauer in Tagen: \t{BestelldauerInTagen,10}\n" +
                $"Meldebestand:       \t{Meldebestand,10}\n" +
                $"Bestellvorschlag: \t{Bestellvorschlag,10}\n";
        }
    }

}
