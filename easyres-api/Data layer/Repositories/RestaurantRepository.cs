using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_layer.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DatabaseContext _context;

        public RestaurantRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public List<Restaurant> GetRestaurants(IQueryFilter filter)
        {
            IQueryable<Restaurant> query = _context.Restaurants;
            if (!string.IsNullOrEmpty(filter.Naam))
            {
                query = query.Where(b => b.Naam.ToLower().Contains(filter.Naam.ToLower().Trim()));
            }
            if (!string.IsNullOrEmpty(filter.Land))
                query = query.Where(b => b.Locatie.Land.ToLower().Contains(filter.Land.ToLower().Trim()));
            if (!string.IsNullOrEmpty(filter.Gemeente))
                query = query.Where(b => b.Locatie.Gemeente.ToLower().Contains(filter.Gemeente.ToLower().Trim()));
            if (!string.IsNullOrEmpty(filter.Type))
                query = query.Where(b => b.Type == filter.Type);
            if (!string.IsNullOrEmpty(filter.Soort))
                query = query.Where(b => b.Soort == filter.Soort);
            if (!string.IsNullOrEmpty(filter.Gerechten))
            {
                var spliString = filter.Gerechten.Split(",");
                foreach (string item in spliString)
                {
                    query = query.Where(b => b.Gerechten.ToLower().Contains(item.ToLower().Trim()));
                }
            }


            if (string.IsNullOrEmpty(filter.SortBy)) filter.SortBy = "default";
            switch (filter.SortBy.ToLower())
            {
                case "naam":
                    if (filter.Direction == "asc")
                        query = query.OrderBy(b => b.Naam);
                    else
                        query = query.OrderByDescending(b => b.Naam);
                    break;
                case "gemeente":
                    if (filter.Direction == "asc")
                        query = query.OrderBy(b => b.Locatie.Gemeente);
                    else
                        query = query.OrderByDescending(b => b.Locatie.Gemeente);
                    break;
                case "type":
                    if (filter.Direction == "asc")
                        query = query.OrderBy(b => b.Type);
                    else
                        query = query.OrderByDescending(b => b.Type);
                    break;
                case "soort":
                    if (filter.Direction == "asc")
                        query = query.OrderBy(b => b.Soort);
                    else
                        query = query.OrderByDescending(b => b.Soort);
                    break;
                case "land":
                    if (filter.Direction == "asc")
                        query = query.OrderBy(b => b.Locatie.Land);
                    else
                        query = query.OrderByDescending(b => b.Locatie.Land);
                    break;
                default:
                    if (filter.Direction == "asc")
                        query = query.OrderBy(b => b.RestaurantId);
                    else
                        query = query.OrderByDescending(b => b.RestaurantId);
                    break;
            }
            query = query.Skip(filter.PageNumber * filter.PageSize);
            if (filter.PageSize <= 0) filter.PageSize = 0;
            query = query.Take(filter.PageSize);
            return query.ToList();
        }

        public List<Restaurant> GetGeadverteerdeRestaurant()
        {
            var geadverteerdeRestaurants = _context.Restaurants
                                        .Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .Where(a => a.IsAdvertentie == true).ToList();
            return geadverteerdeRestaurants;
        }

        public Restaurant GetGeadverteerdeRestaurantBySoort(string soort)
        {
            var geadverteerdRestaurant = _context.Restaurants
                                        .Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .Where(a => a.IsAdvertentie == true)
                                        .FirstOrDefault(a => a.Soort == soort);
            return geadverteerdRestaurant;
        }

        public Restaurant UpdateGeadverteerdeRestaurantBySoort(Restaurant restaurant)
        {
            var oudeAdvertentie = _context.Restaurants
                .Where(a => a.IsAdvertentie == true)
                .FirstOrDefault(a => a.Soort == restaurant.Soort);
            if (oudeAdvertentie != null)
            {
                oudeAdvertentie.IsAdvertentie = false;
            }
            restaurant.IsAdvertentie = true;
            try
            {
                _context.Restaurants.Update(restaurant);
            }
            catch (Exception)
            {
                return null;
            }
            return restaurant;
        }

        public Restaurant GetRestaurant(long id)
        {
            var restaurant = _context.Restaurants.Where(a => a.RestaurantId == id).Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Tafels)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .Include(a => a.Reservaties)
                                        .FirstOrDefault();
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant, long id)
        {
            try
            {
                _context.Restaurants.Update(updatedRestaurant);
            }
            catch (Exception)
            {
                return null;
            }
            return updatedRestaurant;
        }

        public Reservatie AddReservatie(Reservatie reservatie)
        {
            var restaurant = _context.Restaurants.Include(a => a.Menu)
                                                .Include(a => a.Menu.Desserts)
                                                .Include(a => a.Menu.Dranken)
                                                .Include(a => a.Menu.Hoofdgerechten)
                                                .Include(a => a.Menu.Voorgerechten)
                                                .Include(a => a.Reservaties)
                                                .Include(a => a.Openingsuren)
                                                .Include(a => a.Locatie)
                                                .Include(a => a.Tafels)
                                                .Include("Tafels.BezetteMomenten")
                                                .SingleOrDefault(a => a.RestaurantId == reservatie.Restaurant.RestaurantId);
            if (!CheckVoorPlaats(reservatie, restaurant))
                return null;
            var finalReservatie = CreateNewReservationObject(reservatie);
            var tafel = restaurant.Tafels.FirstOrDefault(a => a.TafelNr == finalReservatie.TafelNr);
            var tijdstipInt = int.Parse((finalReservatie.Tijdstip.Split(':'))[0]) + tafel.UrenBezet;
            var tijdstipString = $"{tijdstipInt}:00";
            tafel.BezetteMomenten.Add(
                new Tijdsmoment()
                {
                    Datum = finalReservatie.Datum,
                    Tot = tijdstipString,
                    Van = finalReservatie.Tijdstip
                });
            restaurant.Reservaties.Add(finalReservatie);
            //_context.Restaurants.Update(restaurant);
            return reservatie;
        }

        
        private static Reservatie CreateNewReservationObject(Reservatie reservatie)
        {
            return new Reservatie
            {
                UserId = reservatie.UserId,
                Naam = reservatie.Naam,
                Email = reservatie.Email,
                TelefoonNummer = reservatie.TelefoonNummer,
                Datum = reservatie.Datum,
                Tijdstip = reservatie.Tijdstip,
                AantalPersonen = reservatie.AantalPersonen,
                Restaurant = reservatie.Restaurant,
                TafelNr = reservatie.TafelNr
            };
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        private bool CheckVoorPlaats(Reservatie reservatie, Restaurant restaurant)
        {
            var gevraagdeTijdstip = int.Parse((reservatie.Tijdstip.Split(':'))[0]);

            foreach (Tafel tafel in restaurant.Tafels)
            {
                if (tafel.Zitplaatsen >= reservatie.AantalPersonen)
                {
                    if (tafel.BezetteMomenten.Count <= 1)
                    {
                        reservatie.TafelNr = tafel.TafelNr;
                        return true;
                    }
                    foreach (Tijdsmoment tijdstip in tafel.BezetteMomenten)
                    {
                        if (reservatie.Datum == tijdstip.Datum &&
                            gevraagdeTijdstip >= int.Parse(tijdstip.Tot.Split(':')[0]) ||
                            reservatie.Datum == tijdstip.Datum &&
                            gevraagdeTijdstip <= int.Parse(tijdstip.Van.Split(':')[0]) - tafel.UrenBezet)
                        {
                            reservatie.TafelNr = tafel.TafelNr;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    
    }
}
