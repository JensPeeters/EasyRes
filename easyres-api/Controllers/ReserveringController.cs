using easyres_api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyres_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public List<Reservatie> GetReserveringen(string userid)
        {
            IQueryable<Reservatie> query = context.Reservaties.Include(a => a.Restaurant);
            if (!string.IsNullOrEmpty(userid))
            {
                query = query.Where(b => b.UserId == userid);
            }

            return query.ToList();
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

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<Reservatie> DeleteReservatie(long id)
        {
            IQueryable<Reservatie> query = context.Reservaties;
            var reservatie = query.Where(a => a.ReservatieId == id).FirstOrDefault();
            
            if (reservatie == null)
            return NotFound();

            context.Reservaties.Remove(reservatie);
            context.SaveChanges();
            return NoContent();
        }
    }
}