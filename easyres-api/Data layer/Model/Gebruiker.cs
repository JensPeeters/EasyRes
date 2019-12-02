using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data_layer.Model
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
