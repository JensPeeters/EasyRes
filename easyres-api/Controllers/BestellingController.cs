using easyres_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace easyres_api.Controllers
{
    [Route("api/bestelling")]
    [ApiController]
    public class BestellingController : ControllerBase
    {
        DatabaseContext context;

        public BestellingController(DatabaseContext ctx)
        {
            this.context = ctx;
        }
        [Route("restaurant/{idRes}")]
        [HttpGet]
        public List<Bestelling> GetBestellingenForRestaurant(long idRes)
        {
            var bestellingen = context.Bestellingen.Include(a => a.Dranken)
                                        .Include(a => a.Etenswaren)
                                        .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
            return bestellingen;
        }

        [Route("restaurant/{idRes}/{idGebruiker}")]
        [HttpPost]
        public ActionResult<Bestelling> AddBestelling(long idRes, string idGebruiker, [FromBody] Bestelling bestelling)
        {
            bestelling.Restaurant = context.Restaurants.Where(a => a.RestaurantId == idRes)
                                        .Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .FirstOrDefault();
            bestelling.Gebruiker = context.Gebruikers.Find(idGebruiker);
            context.Bestellingen.Add(bestelling);
            context.SaveChanges();
            return Created("", bestelling);
        }

        [Route("restaurant/{idRes}/{bestelId}")]
        [HttpPut]
        public ActionResult<Bestelling> UpdateBestelling([FromBody]Bestelling bestelling)
        {
            context.Bestellingen.Update(bestelling);
            context.SaveChanges();
            return Created("", bestelling);
        }

        [Route("restaurant/{idRes}/bar")]
        [HttpGet]
        public List<Bestelling> GetBestellingenBar(long idRes)
        {
            return context.Bestellingen.Include(a => a.Dranken)
                .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
        }

        [Route("restaurant/{idRes}/keuken")]
        [HttpGet]
        public List<Bestelling> GetBestellingenKeuken(long idRes)
        {
            return context.Bestellingen.Include(a => a.Etenswaren)
                .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
        }

        [Route("restaurant/{idRes}/{idBestel}")]
        [HttpGet]
        public ActionResult<Bestelling> GetBestellingRestaurantByID(long idRes, long idBestel)
        {
            var bestelling = context.Bestellingen.Where(a => a.BestellingId == idBestel)
                                            .Where(a => a.Restaurant.RestaurantId == idRes)
                                            .Include(a => a.Dranken)
                                            .Include(a => a.Etenswaren)
                                        .FirstOrDefault();
            if (bestelling == null)
                return NotFound();
            return bestelling;
        }

        [Route("restaurant/{idRes}")]
        [HttpPut]
        public ActionResult<Bestelling> UpdateBestellingen([FromBody] Bestelling bestelling, long idRes) {
            context.Bestellingen.Update(bestelling);
            context.SaveChanges();
            return bestelling;
        }

        [Route("gebruiker/{idGebruiker}/{idRes}")]
        [HttpGet]
        public List<Bestelling> GetBestellingenGebruiker(string idGebruiker, long idRes)
        {
            return context.Bestellingen
                .Include(a => a.Dranken)
                .Include(a => a.Etenswaren)
                .Where(e => e.Gebruiker.GebruikersID == idGebruiker)
                .Where(e => e.Restaurant.RestaurantId == idRes).ToList();
        }
    }
}