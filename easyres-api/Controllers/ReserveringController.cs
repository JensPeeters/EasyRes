using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyres_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace easyres_api.Controllers
{
    [Route("api/reservatie")]
    [ApiController]
    public class ReserveringController : ControllerBase
    {
        DatabaseContext context;

        public ReserveringController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [HttpGet]
        public List<Reservatie> GetReserveringen()
        {
            return context.Reservaties.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Reservatie> GetReservatie(long id)
        {
            var reservatie = context.Reservaties.Where(a => a.ReservatieId == id)
                                        .FirstOrDefault();
            if (reservatie == null)
                return NotFound();
            return reservatie;
        }
    }
}