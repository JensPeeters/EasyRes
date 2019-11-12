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
    public class UserController : ControllerBase
    {
        DatabaseContext context;
        public UserController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [Route("{userId}")]
        [HttpPost]
        public ActionResult<Sessie> CreateUser(string userId)
        {
            var gebruiker = context.Gebruikers.FirstOrDefault(a => a.GebruikersID == userId);
            if (gebruiker == null)
            {
                gebruiker = new Gebruiker()
                {
                    Bestellingen = new List<Bestelling>(),
                    Sessies = new List<Sessie>(),
                    GebruikersID = userId,
                    Restaurants = new List<Restaurant>()
                };
                context.Gebruikers.Add(gebruiker);
                context.SaveChanges();
                return Created("", gebruiker);
            }
            return NotFound(); 
        }
    }
}