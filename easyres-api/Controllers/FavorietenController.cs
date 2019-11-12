using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyres_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavorietenController : ControllerBase
    {
        DatabaseContext context;
        public FavorietenController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [Route("{gebruikersId}")]
        [HttpGet]
        public ActionResult<Gebruiker> GetFavorieteRestaurants(string gebruikersId, string naam)
        {
            var favorieten = context.Gebruikers.Include(a => a.Restaurants)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            if (!string.IsNullOrEmpty(naam))
                favorieten.Restaurants = favorieten.Restaurants.Where(b => b.Naam.ToLower()
                                                           .Contains(naam.ToLower().Trim())).ToList();
            if (favorieten == null)
                return NotFound();
            return favorieten;
        }
        [Route("{gebruikersId}/{restaurantId}")]
        [HttpPost]
        public ActionResult<Gebruiker> AddFavorieteRestaurant(string gebruikersId, long restaurantId)
        {
            var gebruiker = context.Gebruikers.Include(a => a.Restaurants)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            var restaurant = context.Restaurants.Where(a => a.RestaurantId == restaurantId)
                                                .FirstOrDefault();
            if (gebruiker == null)
                return NotFound();
            gebruiker.Restaurants.Add(restaurant);
            context.SaveChanges();
            return Created("", restaurant);
        }
        [Route("{gebruikersId}/{restaurantId}")]
        [HttpDelete]
        public ActionResult<Gebruiker> DeleteReservatie(string gebruikersId, long restaurantId)
        {
            var query = context.Gebruikers.Include(a => a.Restaurants)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            var favorieten = query.Restaurants.Where(a => a.RestaurantId == restaurantId).FirstOrDefault();

            if (favorieten == null)
                return NotFound();
            query.Restaurants.Remove(favorieten);
            context.Gebruikers.Update(query);
            context.SaveChanges();
            return NoContent();
        }
    }
}