using Business_layer.Interfaces;
using Data_layer.Model;
using Microsoft.AspNetCore.Mvc;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavorietenController : ControllerBase
    {
        private readonly IFavorietenFacade _favorietFacade;

        public FavorietenController(IFavorietenFacade favorietFacade)
        {
            this._favorietFacade = favorietFacade;
        }

        [Route("{gebruikersId}")]
        [HttpGet]
        public ActionResult<Gebruiker> GetFavorieteRestaurants(string gebruikersId, string naam)
        {
            var favorieten = _favorietFacade.GetFavorieteRestaurants(gebruikersId, naam);
            if (favorieten == null)
                return NotFound();
            return favorieten;
        }
        [Route("{gebruikersId}/{restaurantId}")]
        [HttpPost]
        public ActionResult<Gebruiker> AddFavorieteRestaurant(string gebruikersId, long restaurantId)
        {
            var restaurant = _favorietFacade.AddFavorieteRestaurant(gebruikersId, restaurantId);
            if (restaurant == null)
                return NotFound();
            return Created("", restaurant);
        }
        [Route("{gebruikersId}/{restaurantId}")]
        [HttpDelete]
        public ActionResult<Gebruiker> DeleteReservatie(string gebruikersId, long restaurantId)
        {
            var gebruiker = _favorietFacade.DeleteReservatie(gebruikersId, restaurantId);
            if (gebruiker == null)
                return NotFound();
            return NoContent();
        }
    }
}