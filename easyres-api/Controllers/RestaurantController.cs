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
        public List<Restaurant> GetCourses()
        {
            return context.Restaurants.Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .ToList();
        }
    }
}