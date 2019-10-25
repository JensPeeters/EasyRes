using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace easyres_api.Model
{
    public class Bestelling
    {
        [Key]
        public int BestellingId { get; set; }

        public List<Product> Etenswaren { get; set; }
        public List<Product> Dranken { get; set; }
        public int RestaurantId { get; set; }

        public int TafelNr { get; set; }
    }
}
