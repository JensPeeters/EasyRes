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
    }
}