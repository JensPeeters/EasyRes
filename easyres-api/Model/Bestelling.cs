using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Bestelling
    {
        [Key]
        public int BestellingId { get; set; }
        public List<Product> BesteldeEtenswaren { get; set; }
        public List<Product> BesteldeDranken { get; set; }

        public int TafelNr { get; set; }
    }
}
