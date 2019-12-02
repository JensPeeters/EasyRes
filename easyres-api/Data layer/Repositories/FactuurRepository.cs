using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public List<Factuur> GetFacturen(string idGebruiker)
        {
            Gebruiker gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            if (gebruiker == null)
                return null;
            List<Factuur> facturen = _context.Facturen
                                            .Include(a => a.Producten)
                                            .Include(a => a.Restaurant)
                                            .Where(a => a.Gebruiker == gebruiker).ToList();
            return facturen;
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
            foreach (var bestelling in Bestellingen)
            {
                foreach (Product eten in bestelling.Etenswaren)
                {
                    CheckList(eten);

                }
                foreach (Product drinken in bestelling.Dranken)
                {
                    CheckList(drinken);
                }
            }

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
