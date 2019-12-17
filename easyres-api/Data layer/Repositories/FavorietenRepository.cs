using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data_layer.Repositories
{
    public class FavorietenRepository : IFavorietenRepository
    {
        private readonly DatabaseContext _context;

        public FavorietenRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Gebruiker GetFavorieteRestaurants(string gebruikersId, string naam)
        {
            var gebruiker = _context.Gebruikers.Include(a => a.Favorieten)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            if (!string.IsNullOrEmpty(naam))
                gebruiker.Favorieten = gebruiker.Favorieten.Where(b => b.Naam.ToLower()
                                                           .Contains(naam.ToLower().Trim())).ToList();
            return gebruiker;
        }

        public Gebruiker AddFavorieteRestaurant(string gebruikersId, long restaurantId)
        {
            var gebruiker = _context.Gebruikers.Include(a => a.Favorieten)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            if (gebruiker == null)
                return null;
            var restaurant = _context.Restaurants.Where(a => a.RestaurantId == restaurantId)
                                                .FirstOrDefault();
            gebruiker.Favorieten.Add(restaurant);
            return gebruiker;
        }

        public Gebruiker DeleteFavoriet(string gebruikersId, long restaurantId)
        {
            var gebruiker = _context.Gebruikers.Include(a => a.Favorieten)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            try
            {
                var favoriet = gebruiker.Favorieten.Where(a => a.RestaurantId == restaurantId)
                                              .FirstOrDefault();
                gebruiker.Favorieten.Remove(favoriet);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            return gebruiker;
        }
    }
}
