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
            var reservatie = context.Gebruikers.Include(a => a.Restaurants)
                                               .Where(a => a.GebruikersID == gebruikersId)
                                               .FirstOrDefault();
            if (!string.IsNullOrEmpty(naam))
                reservatie.Restaurants = reservatie.Restaurants.Where(b => b.Naam.ToLower()
                                                           .Contains(naam.ToLower().Trim())).ToList();
            if (reservatie == null)
                return NotFound();
            return reservatie;
        }
    }
}