using Business_layer.Interfaces;
using Data_layer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace easyres_api.Controllers
{
    [Route("api/bestelling")]
    [ApiController]
    public class BestellingController : ControllerBase
    {
        IBestellingenFacade _bestellingFacade;

        public BestellingController(IBestellingenFacade bestellingFacade)
        {
            this._bestellingFacade = bestellingFacade;
        }
        [Route("restaurant/{idRes}")]
        [HttpGet]
        public List<Bestelling> GetBestellingenForRestaurant(long idRes)
        {
            return _bestellingFacade.GetBestellingenForRestaurant(idRes);
        }

        [Route("restaurant/{idRes}/{idGebruiker}")]
        [HttpPost]
        public ActionResult<Bestelling> AddBestelling(long idRes, string idGebruiker, [FromBody] Bestelling bestelling)
        {
            var createdBestelling = _bestellingFacade.AddBestelling(idRes, idGebruiker, bestelling);
            return Created("", createdBestelling);
        }

        [Route("restaurant/{idRes}/{bestelId}")]
        [HttpPut]
        public ActionResult<Bestelling> UpdateBestelling([FromBody]Bestelling bestelling)
        {
            var updatedBestelling = _bestellingFacade.UpdateBestelling(bestelling);
            return Created("", updatedBestelling);
        }

        [Route("restaurant/{idRes}/bar")]
        [HttpGet]
        public List<Bestelling> GetBestellingenBar(long idRes)
        {
            return _bestellingFacade.GetBestellingenBar(idRes);
        }

        [Route("restaurant/{idRes}/keuken")]
        [HttpGet]
        public List<Bestelling> GetBestellingenKeuken(long idRes)
        {
            return _bestellingFacade.GetBestellingenKeuken(idRes);
        }

        [Route("restaurant/{idRes}/{idBestel}")]
        [HttpGet]
        public ActionResult<Bestelling> GetBestellingRestaurantByID(long idRes, long idBestel)
        {
            return _bestellingFacade.GetBestellingRestaurantByID(idRes, idBestel);
        }

        [Route("restaurant/{idRes}")]
        [HttpPut]
        public ActionResult<Bestelling> UpdateBestellingen([FromBody] Bestelling bestelling, long idRes) {
            var updatedBestelling = _bestellingFacade.UpdateBestellingen(bestelling, idRes);
            return Created("", updatedBestelling);
        }

        [Route("gebruiker/{idGebruiker}/{idRes}")]
        [HttpGet]
        public List<Bestelling> GetBestellingenGebruiker(string idGebruiker, long idRes)
        {
            return _bestellingFacade.GetBestellingenGebruiker(idGebruiker, idRes);
        }
    }
}