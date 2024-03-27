using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kontaktverwaltung.Models
{
    public class Adresse
    {
        [JsonPropertyName("post code")]
        public string postcode { get; set; }
        public string country { get; set; }
        [JsonPropertyName("country abbreviation")]
        public string countryabbreviation { get; set; }
        public Place[] places { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("place name")]
        public string placename { get; set; }
        public string longitude { get; set; }
        public string state { get; set; }
        [JsonPropertyName("state abbreviation")]
        public string stateabbreviation { get; set; }
        public string latitude { get; set; }
    }

}
