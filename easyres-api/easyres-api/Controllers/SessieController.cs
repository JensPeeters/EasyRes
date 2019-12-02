using System.Collections.Generic;
using Business_layer.Interfaces;
using Data_layer.Model;
using Microsoft.AspNetCore.Mvc;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessieController : ControllerBase
    {
        private readonly ISessieFacade _sessieFacade;

        public SessieController(ISessieFacade sessieFacade)
        {
            this._sessieFacade = sessieFacade;
        }

        [Route("{userId}/{restaurantId}/{tafelNr}")]
        [HttpPost]
        public ActionResult<Sessie> CreateSession(string userId, int restaurantId, int tafelNr)
        {
            var sessie = _sessieFacade.CreateSession(userId, restaurantId, tafelNr);
            if (sessie == null)
                return Conflict();
            return Created("", sessie);
        }

        [Route("{userId}")]
        [HttpGet]
        public List<Sessie> GetSessionsByUserId(string userId)
        {
            return _sessieFacade.GetSessionsByUserId(userId);
        }
    }
}