using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_layer.Repositories
{
    public class FactuurRepository : IFactuurRepository
    {
        private readonly DatabaseContext _context;

        public FactuurRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public Factuur GetFactuur(string idGebruiker, long idRes)
        {
            Gebruiker gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            Restaurant restaurant = _context.Restaurants.Where(a => a.RestaurantId == idRes).FirstOrDefault();
            if (gebruiker == null || restaurant == null)
                return null;
            Factuur factuur = _context.Facturen
                                     .Include(a => a.Producten)
                                     .Include(a => a.Restaurant)
                                     .Where(a => a.Restaurant == restaurant)
                                     .Where(a => a.Gebruiker == gebruiker).LastOrDefault();
            return factuur;
        }
        public List<Factuur> GetFacturen(string idGebruiker, string sortBy)
        {
            Gebruiker gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            if (gebruiker == null)
                return null;
            IQueryable<Factuur> facturen = _context.Facturen.Include(a => a.Producten)
                                                            .Include(a => a.Restaurant)
                                                            .Where(a => a.Gebruiker == gebruiker);
            if (string.IsNullOrEmpty(sortBy)) sortBy = "default";
            switch (sortBy.ToLower())
            {
                case "datum":
                    facturen = facturen.OrderBy(b => b.Datum);
                    break;
                case "restaurant":
                    facturen = facturen.OrderBy(b => b.Restaurant);
                    break;
                case "factuurnummer":
                    facturen = facturen.OrderBy(b => b.Id);
                    break;
                case "prijs":
                    facturen = facturen.OrderBy(b => b.TotaalPrijs);
                    break;
                default:
                    facturen = facturen.OrderBy(b => b.Datum);
                    break;
            }
            return facturen.ToList();
        }

        public List<Factuur> GetFacturenRestaurant(int idRes)
        {
            return _context.Facturen.Where(a => a.Restaurant.RestaurantId == idRes)
                .Include(a => a.Restaurant)
                .Include(a => a.Gebruiker)
                .Include(a => a.Producten).ToList();
        }

        public Factuur GetFactuurById(string idGebruiker, long idFactuur)
        {
            Gebruiker gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            if (gebruiker == null)
                return null;
            Factuur factuur = _context.Facturen
                                     .Include(a => a.Producten)
                                     .Include(a => a.Restaurant)
                                     .Where(a => a.Gebruiker == gebruiker)
                                     .Where(a => a.Id == idFactuur).LastOrDefault();
            return factuur;
        }

        public Factuur GenerateFactuur(string idGebruiker, long idRes, string mail)
        {
            Gebruiker gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            Restaurant restaurant = _context.Restaurants.Where(a => a.RestaurantId == idRes).FirstOrDefault();
            if (gebruiker == null || restaurant == null)
                return null;
            List<Bestelling> Bestellingen = _context.Bestellingen
                                        .Include(a => a.Etenswaren)
                                        .Include(a => a.Dranken)
                                        .Where(a => a.Restaurant == restaurant)
                                        .Where(a => a.Gebruiker == gebruiker).ToList();
            List<Product> producten = new List<Product>();
            var tafelNr = 0;
            foreach (var bestelling in Bestellingen)
            {
                tafelNr = bestelling.TafelNr;
                foreach (Product eten in bestelling.Etenswaren)
                {
                    CheckList(eten);

                }
                foreach (Product drinken in bestelling.Dranken)
                {
                    CheckList(drinken);
                }
            }
            if (tafelNr == 0)
                return null;
            void CheckList(Product product)
            {
                var tempProduct = producten.Find(a => a.Naam == product.Naam);
                if (tempProduct == null)
                {
                    producten.Add(product);
                }
                else
                {
                    tempProduct.Aantal += product.Aantal;
                    producten.Find(a => a.Naam == product.Naam).Aantal = tempProduct.Aantal;
                }
            }

            Factuur factuur = new Factuur()
            {
                TafelNr = tafelNr,
                Gebruiker = gebruiker,
                Restaurant = restaurant,
                Producten = producten,
                Datum = DateTime.Now,
                Betaald = false
            };
            _context.Facturen.Add(factuur);
            return factuur;
        }

        public Factuur UpdateFactuur(Factuur factuur)
        {
            var UpdateFactuur = _context.Facturen.Where(a => a.Id == factuur.Id).FirstOrDefault();
            if (UpdateFactuur == null)
                return null;
            UpdateFactuur.Betaald = factuur.Betaald;
            return UpdateFactuur;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
