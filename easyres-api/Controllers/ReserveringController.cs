using easyres_api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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