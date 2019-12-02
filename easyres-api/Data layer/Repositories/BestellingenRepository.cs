using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_layer.Repositories
{
    public class BestellingenRepository : IBestellingenRepository
    {
        private readonly DatabaseContext _context;

        public BestellingenRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public List<Bestelling> GetBestellingenForRestaurant(long idRes)
        {
            var bestellingen = _context.Bestellingen.Include(a => a.Dranken)
                                        .Include(a => a.Etenswaren)
                                        .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
            return bestellingen;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Bestelling AddBestelling(long idRes, string idGebruiker, Bestelling bestelling)
        {
            bestelling.Restaurant = _context.Restaurants.Where(a => a.RestaurantId == idRes)
                                        .Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .FirstOrDefault();
            bestelling.Gebruiker = _context.Gebruikers.Find(idGebruiker);
            _context.Bestellingen.Add(bestelling);
            return  bestelling;
        }

        public Bestelling UpdateBestelling(Bestelling bestelling)
        {
            _context.Bestellingen.Update(bestelling);
            return bestelling;
        }

        public List<Bestelling> GetBestellingenBar(long idRes)
        {
            return _context.Bestellingen.Include(a => a.Dranken)
                .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
        }
        public List<Bestelling> GetBestellingenKeuken(long idRes)
        {
            return _context.Bestellingen.Include(a => a.Etenswaren)
                .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
        }

        public Bestelling GetBestellingRestaurantByID(long idRes, long idBestel)
        {
            var bestelling = _context.Bestellingen.Where(a => a.BestellingId == idBestel)
                                            .Where(a => a.Restaurant.RestaurantId == idRes)
                                            .Include(a => a.Dranken)
                                            .Include(a => a.Etenswaren)
                                        .FirstOrDefault();
            return bestelling;
        }

        public Bestelling UpdateBestellingen(Bestelling bestelling, long idRes)
        {
            _context.Bestellingen.Update(bestelling);
            return bestelling;
        }

        public List<Bestelling> GetBestellingenGebruiker(string idGebruiker, long idRes)
        {
            return _context.Bestellingen
                .Include(a => a.Dranken)
                .Include(a => a.Etenswaren)
                .Where(e => e.Gebruiker.GebruikersID == idGebruiker)
                .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
        }
    }
}
