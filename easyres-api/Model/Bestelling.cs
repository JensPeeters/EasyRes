using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public double TotaalPrijs
        {
            get
            {
                double tempPrijs = 0;
                foreach (Product product in Etenswaren.Concat(Dranken))
                {
                    tempPrijs += product.Prijs * product.Aantal;
                }
                return tempPrijs;
            }
        }

        public bool EtenGereed { get; set; }
        public bool DrinkenGereed { get; set; }

        public int TafelNr { get; set; }
    }
}
