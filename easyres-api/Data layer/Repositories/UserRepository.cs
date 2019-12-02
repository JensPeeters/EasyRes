using Data_layer.Interfaces;
using Data_layer.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data_layer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public User CreateUser(string userType, string userId)
        {
            switch (userType)
            {
                case "gebruiker":
                    var gebruiker = _context.Gebruikers.FirstOrDefault(a => a.GebruikersID == userId);
                    if (gebruiker == null)
                    {
                        gebruiker = new Gebruiker()
                        {
                            Bestellingen = new List<Bestelling>(),
                            Sessies = new List<Sessie>(),
                            GebruikersID = userId,
                            Favorieten = new List<Restaurant>()
                        };
                        _context.Gebruikers.Add(gebruiker);
                        return gebruiker;
                    }
                    else
                    {
                        return null;
                    }
                case "uitbater":
                    var uitbater = _context.Uitbaters.FirstOrDefault(a => a.GebruikersID == userId);
                    if (uitbater == null)
                    {
                        uitbater = new Uitbater()
                        {
                            GebruikersID = userId,
                            RestaurantId = 0
                        };
                        _context.Uitbaters.Add(uitbater);
                        return uitbater;
                    }
                    else
                    {
                        return null;
                    }
                default:
                    return null;
            }
        }

        public Gebruiker IsGebruiker(string userId)
        {
            var gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == userId)
                                              .FirstOrDefault();
            return gebruiker;
        }

        public Uitbater IsUitbater(string userId)
        {
            var uitbater = _context.Uitbaters.Where(a => a.GebruikersID == userId)
                                            .FirstOrDefault();
            return uitbater;
        }

        public User UpdateGebruiker(string userId, Gebruiker updateGebruiker)
        {
            var gebruiker = _context.Gebruikers.Where(a => a.GebruikersID == userId)
                                              .FirstOrDefault();
            gebruiker.GetFactuurByEmail = updateGebruiker.GetFactuurByEmail;
            return gebruiker;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
