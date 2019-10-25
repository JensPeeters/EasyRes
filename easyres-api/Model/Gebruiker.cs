using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Gebruiker
    {
        public int ID { get; set; }
        public string GebruikersID { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
