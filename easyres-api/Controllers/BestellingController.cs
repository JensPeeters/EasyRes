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
    [Route("api/restaurant")]
    [ApiController]
    public class BestellingController : ControllerBase
    {
        DatabaseContext context;

        public BestellingController(DatabaseContext ctx)
        {
            this.context = ctx;
        }
        [Route("{id}/bestelling")]
        [HttpGet]
        public List<Bestelling> GetBestellingen(long id)
        {
            return context.Bestellingen.Include(a => a.Dranken)
                                        .Include(a => a.Etenswaren)
                                        .Where(e => e.RestaurantId == id).ToList();
        }

        [Route("{id}/bestelling")]
        [HttpPost]
        public ActionResult<Bestelling> AddBestelling([FromBody] Bestelling bestelling)
        {
            context.Bestellingen.Add(bestelling);
            context.SaveChanges();
            return Created("", bestelling);
        }

        [Route("{id}/bestelling/bar")]
        [HttpGet]
        public List<Bestelling> GetBestellingenBar(long id)
        {
            return context.Bestellingen.Include(a => a.Dranken)
                .Where(e => e.RestaurantId == id).ToList();
        }

        [Route("{id}/bestelling/keuken")]
        [HttpGet]
        public List<Bestelling> GetBestellingenKeuken(long id)
        {
            return context.Bestellingen.Include(a => a.Etenswaren)
                .Where(e => e.RestaurantId == id).ToList();
        }

        [Route("{id}/bestelling/{idBestel}")]
        [HttpGet]
        public ActionResult<Bestelling> GetBestelling(long id,long idBestel)
        {
            var bestelling = context.Bestellingen.Where(a => a.BestellingId == idBestel)
                                            .Where(a => a.RestaurantId == id)
                                        .FirstOrDefault();
            if (bestelling == null)
                return NotFound();
            return bestelling;
        }
    }
}