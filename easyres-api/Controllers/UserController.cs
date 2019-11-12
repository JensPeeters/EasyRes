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

        [Route("{userType}/{userId}")]
        [HttpPost]
        public ActionResult<User> CreateUser(string userType, string userId)
        {
            if (userType == "gebruiker")
            {
                var gebruiker = context.Gebruikers.FirstOrDefault(a => a.GebruikersID == userId);
                if (gebruiker == null)
                {
                    gebruiker = new Gebruiker()
                    {
                        Bestellingen = new List<Bestelling>(),
                        Sessies = new List<Sessie>(),
                        GebruikersID = userId,
                        Favorieten = new List<Restaurant>()
                    };
                    context.Gebruikers.Add(gebruiker);
                    context.SaveChanges();
                    return Created("", gebruiker);
                }
                else
                {
                    return NotFound();
                }
            }
            else if (userType == "uitbater")
            {
                var uitbater = context.Uitbaters.FirstOrDefault(a => a.GebruikersID == userId);
                if (uitbater == null)
                {
                    uitbater = new Uitbater()
                    {
                        GebruikersID = userId,
                        RestaurantId = 0
                    };
                    context.Uitbaters.Add(uitbater);
                    context.SaveChanges();
                    return Created("", uitbater);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}