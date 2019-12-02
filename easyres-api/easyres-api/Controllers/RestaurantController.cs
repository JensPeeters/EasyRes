using Business_layer.Exceptions;
using Business_layer.Interfaces;
using Data_layer.Interfaces;
using Data_layer.Model;
using easyres_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantFacade _restaurantFacade;

        public RestaurantController(IRestaurantFacade restaurantFacade)
        {
            this._restaurantFacade = restaurantFacade;
        }

        [HttpGet]
        public List<Restaurant> GetRestaurants([FromQuery]IQueryFilter filter)
        {
            return _restaurantFacade.GetRestaurants(filter);
        }

        [Route("advertentie")]
        [HttpGet]
        public ActionResult<List<Restaurant>> GetGeadverteerdeRestaurant()
        {
            var geadverteerdeRestaurants = _restaurantFacade.GetGeadverteerdeRestaurant();
            if (geadverteerdeRestaurants == null)
                return NotFound();
            return geadverteerdeRestaurants;
        }

        [Route("advertentie/{soort}")]
        [HttpGet]
        public ActionResult<Restaurant> GetGeadverteerdeRestaurantBySoort(string soort)
        {
            var geadverteerdRestaurant = _restaurantFacade.GetGeadverteerdeRestaurantBySoort(soort);
            if (geadverteerdRestaurant == null)
                return NotFound();
            return geadverteerdRestaurant;
        }

        [Route("advertentie")]
        [HttpPut]
        public ActionResult<Restaurant> UpdateGeadverteerdeRestaurantBySoort([FromBody] Restaurant restaurant)
        {
            var updatedRestaurant = _restaurantFacade.UpdateGeadverteerdeRestaurantBySoort(restaurant);
            if (updatedRestaurant == null)
                return NotFound();
            return updatedRestaurant;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Restaurant> GetRestaurant(long id)
        {
            var restaurant = _restaurantFacade.GetRestaurant(id);
            if (restaurant == null)
                return NotFound();
            return restaurant;
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult<Restaurant> UpdateRestaurant([FromBody]Restaurant restaurant, long id)
        {
            var updatedRestaurant = _restaurantFacade.UpdateRestaurant(restaurant, id);
            if (updatedRestaurant == null)
                return NotFound();
            return updatedRestaurant;
        }

        [Route("{id}/reservatie")]
        [HttpGet]
        public ActionResult<List<Reservatie>> GetRestaurantReservations(long id)
        {
            var restaurant = _restaurantFacade.GetRestaurant(id);
            if (restaurant == null)
                return NotFound();
            return restaurant.Reservaties;
        }

        [Route("{id}/reservatie")]
        [HttpPost]
        public ActionResult<Reservatie> AddReservatie([FromBody] Reservatie reservatie)
        {
            try
            {
                _restaurantFacade.AddReservatie(reservatie);
            }
            catch (RestaurantVolzetException)
            {
                return Conflict("Gekozen tijdstip is al volzet.");
            }
            return Created("", reservatie);
        }
    }
}