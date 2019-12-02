using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data_layer.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly DatabaseContext _context;

        public SessieRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Sessie CreateSession(string userId, int restaurantId, int tafelNr)
        {
            var gebruiker = _context.Gebruikers.Include(a => a.Sessies).FirstOrDefault(a => a.GebruikersID == userId);
            var restaurant = _context.Restaurants.FirstOrDefault(a => a.RestaurantId == restaurantId);
            if (gebruiker == null || restaurant == null)
                return null;
            var sessie = new Sessie()
            {
                Gebruiker = gebruiker,
                Restaurant = restaurant,
                TafelNr = tafelNr
            };
            gebruiker.Sessies.Add(sessie);
            return sessie;
        }

        public List<Sessie> GetSessionsByUserId(string userId)
        {
            IQueryable<Sessie> query = _context.Sessies.Include(a => a.Gebruiker)
                                                         .Include(a => a.Restaurant)
                                                         .Where(a => a.Gebruiker.GebruikersID == userId);
            return query.ToList();
        }
    }
}
