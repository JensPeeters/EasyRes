using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Gebruiker : User
    {
        public List<Restaurant> Favorieten { get; set; }
        [JsonIgnore]
        public List<Bestelling> Bestellingen { get; set; }
        [JsonIgnore]
        public List<Sessie> Sessies { get; set; }
        public bool GetFactuurByEmail { get; set; } = true;
    }
}
