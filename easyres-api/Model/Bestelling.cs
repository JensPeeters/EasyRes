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
        public Restaurant Restaurant { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public bool EtenGereed { get; set; }
        public bool DrinkenGereed { get; set; }

        public int TafelNr { get; set; }
    }
}
