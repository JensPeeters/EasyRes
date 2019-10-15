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
    public class BestellingController : ControllerBase
    {
        DatabaseContext context;

        public BestellingController(DatabaseContext ctx)
        {
            this.context = ctx;
        }
        [HttpGet]
        public List<Bestelling> GetBestellingen()
        {
            return context.Bestellingen.Include(a => a.BesteldeDranken)
                                        .Include(a => a.BesteldeEtenswaren).ToList();
        }

        [Route("bar")]
        [HttpGet]
        public List<Bestelling> GetBestellingenBar()
        {
            return context.Bestellingen.Include(a => a.BesteldeDranken).ToList();
        }

        [Route("keuken")]
        [HttpGet]
        public List<Bestelling> GetBestellingenKeuken()
        {
            return context.Bestellingen.Include(a => a.BesteldeEtenswaren).ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Bestelling> GetBestelling(long id)
        {
            var bestelling = context.Bestellingen.Where(a => a.BestellingId == id)
                                        .FirstOrDefault();
            if (bestelling == null)
                return NotFound();
            return bestelling;
        }
    }
}