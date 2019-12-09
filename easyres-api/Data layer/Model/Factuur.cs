using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_layer.Model
{
    public class Factuur
    {
        [Key]
        public int Id { get; set; }
        public List<Product> Producten { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime Datum { get; set; }
        public bool Betaald { get; set; }
        public int TafelNr { get; set; }
        public double TotaalPrijs
        {
            get
            {
                double tempPrijs = 0;
                if (Producten != null)
                    tempPrijs = BerekenTotaal(tempPrijs, Producten);
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
    }
}
