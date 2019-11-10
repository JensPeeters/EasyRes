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
    public class SessieController : ControllerBase
    {
        DatabaseContext context;
        public SessieController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [Route("{userId}/{restaurantId}/{tafelNr}")]
        [HttpPost]
        public ActionResult<Sessie> CreateSession(string userId, int restaurantId, int tafelNr)
        {
            var gebruiker = context.Gebruikers.Include(a => a.Sessies).FirstOrDefault(a => a.GebruikersID == userId);
            if(gebruiker == null)
            {
                gebruiker = new Gebruiker()
                {
                    Bestellingen = new List<Bestelling>(),
                    Sessies = new List<Sessie>(),
                    GebruikersID = userId,
                    Restaurants = new List<Restaurant>()
                };
                context.Gebruikers.Add(gebruiker);
            }
            var restaurant = context.Restaurants.FirstOrDefault(a => a.RestaurantId == restaurantId);
            var sessie = new Sessie()
            {
                Gebruiker = gebruiker,
                Restaurant = restaurant,
                TafelNr = tafelNr
            };
            gebruiker.Sessies.Add(sessie);
            context.SaveChanges();
            return Created("", sessie);
        }

        [Route("{userId}")]
        [HttpGet]
        public List<Sessie> GetSessionsByUserId(string userId)
        {
            IQueryable<Sessie> query = context.Sessies.Include(a => a.Gebruiker)
                                                         .Include(a => a.Restaurant)
                                                         .Where(a => a.Gebruiker.GebruikersID == userId);
            
            return query.ToList();
        }
    }
}