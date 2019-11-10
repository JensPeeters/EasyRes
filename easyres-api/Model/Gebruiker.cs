using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Gebruiker
    {
        [Key]
        public string GebruikersID { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        [JsonIgnore]
        public List<Bestelling> Bestellingen { get; set; }
        [JsonIgnore]
        public List<Sessie> Sessies { get; set; }

    }
}
