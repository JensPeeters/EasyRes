
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Data_layer.Model;
using Business_layer.Interfaces;

namespace easyres_api.Controllers
{
    [Route("api/reservatie")]
    [ApiController]
    public class ReserveringController : ControllerBase
    {
        private readonly IReserveringenFacade _reserveringFacade;

        public ReserveringController(IReserveringenFacade reserveringFacade)
        {
            this._reserveringFacade = reserveringFacade;
        }

        [HttpGet]
        public List<Reservatie> GetReserveringen(string userid)
        {
            return _reserveringFacade.GetReserveringen(userid);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Reservatie> GetReservatie(long id)
        {
            var reservatie = _reserveringFacade.GetReservatie(id);
            if (reservatie == null)
                return NotFound();
            return reservatie;
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<Reservatie> DeleteReservatie(long id, string user = "gebruiker")
        {
            var reservatie = _reserveringFacade.DeleteReservatie(id, user);
            if (reservatie == null)
                return NotFound();
            return NoContent();
        }
    }
}