using System;
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
        public double TotaalPrijs
        {
            get
            {
                double tempPrijs = 0;
                if (Dranken != null)
                    tempPrijs = BerekenTotaal(tempPrijs,Dranken);
                if (Etenswaren != null)
                    tempPrijs = BerekenTotaal(tempPrijs, Etenswaren);
                return tempPrijs;
            }
        }

        private double BerekenTotaal(double tempPrijs, List<Product> productenLijst)
        {
            foreach (Product product in productenLijst)
            {
                tempPrijs += product.Prijs * product.Aantal;
            }
            return tempPrijs;
        }

        public bool EtenGereed { get; set; }
        public bool DrinkenGereed { get; set; }
        public DateTime HuidigeTijd { get; set; }
        public string EetTijdKlaar { get; set; }
        public string DrinkTijdKlaar { get; set; }
        public int TafelNr { get; set; }
    }
}
