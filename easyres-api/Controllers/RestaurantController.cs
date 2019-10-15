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
    public class RestaurantController : ControllerBase
    {
        DatabaseContext context;

        public RestaurantController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [HttpGet]
        public List<Restaurant> GetRestaurants()
        {
            return context.Restaurants.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Restaurant> GetRestaurant(long id)
        {
            var restaurant = context.Restaurants.Where(a => a.RestaurantId == id).Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .FirstOrDefault();
            if (restaurant == null)
                return NotFound();
            return restaurant;
        }
        [Route("{id}/reservatie")]
        [HttpGet]
        public List<Reservatie> GetRestaurantReservations(long id)
        {
            var restaurant = context.Restaurants.Include(a => a.Reservaties)
                                                .Include(a => a.Menu)
                                                .Include(a => a.Menu.Desserts)
                                                .Include(a => a.Menu.Dranken)
                                                .Include(a => a.Menu.Hoofdgerechten)
                                                .Include(a => a.Menu.Voorgerechten)
                                                .Include(a => a.Locatie)
                                                .SingleOrDefault(a => a.RestaurantId == id);
            return restaurant.Reservaties;
        }

        [Route("{id}/reservatie")]
        [HttpPost]
        public ActionResult<Reservatie> AddReservatie([FromBody] Reservatie reservatie)
        {
            var restaurant = context.Restaurants.Include(a => a.Menu)
                                                .Include(a => a.Menu.Desserts)
                                                .Include(a => a.Menu.Dranken)
                                                .Include(a => a.Menu.Hoofdgerechten)
                                                .Include(a => a.Menu.Voorgerechten)
                                                .Include(a => a.Reservaties)
                                                .Include(a => a.Openingsuren)
                                                .Include(a => a.Locatie)
                                                 .Include(a => a.Locatie)
                                                 .SingleOrDefault(a => a.RestaurantId == reservatie.Restaurant.RestaurantId);

            Reservatie tempReservatie = new Reservatie();

            tempReservatie.AantalPersonen = reservatie.AantalPersonen;
            tempReservatie.Datum = reservatie.Datum;
            tempReservatie.Email = reservatie.Email;
            tempReservatie.Naam = reservatie.Naam;
            tempReservatie.Restaurant = reservatie.Restaurant;
            tempReservatie.TelefoonNummer = reservatie.TelefoonNummer;
            restaurant.Reservaties.Add(tempReservatie);
            context.Restaurants.Update(restaurant);
            context.SaveChanges();
            return Created("", reservatie);
        }


    }
}