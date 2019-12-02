using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_layer.Interfaces;
using Data_layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactuurController : ControllerBase
    {
        private readonly IFactuurFacade _factuurFacade;

        public FactuurController(IFactuurFacade factuurFacade)
        {
            this._factuurFacade = factuurFacade;
        }

        [Route("{idGebruiker}/{idRes}")]
        [HttpGet]
        public ActionResult<Factuur> GetFactuur(string idGebruiker, long idRes)
        {
            var factuur = _factuurFacade.GetFactuur(idGebruiker, idRes);
            if (factuur == null)
                return NotFound();
            return factuur;
        }

        [Route("{idGebruiker}")]
        [HttpGet]
        public ActionResult<List<Factuur>> GetFacturen(string idGebruiker)
        {
            var facturen = _factuurFacade.GetFacturen(idGebruiker);
            if (facturen == null)
                return NotFound();
            return facturen;
        }

        [Route("{idGebruiker}/factuur/{idFactuur}")]
        [HttpGet]
        public ActionResult<Factuur> GetFactuurById(string idGebruiker, long idFactuur)
        {
            var factuur = _factuurFacade.GetFactuurById(idGebruiker, idFactuur);
            if (factuur == null)
                return NotFound();
            return factuur;
        }

        [Route("{idGebruiker}/{idRes}/{mail}")]
        [HttpPost]
        public ActionResult<Factuur> GenerateFactuur(string idGebruiker, long idRes, string mail)
        {
            var factuur = _factuurFacade.GenerateFactuur(idGebruiker, idRes, mail);
            if (factuur == null)
                return Conflict();
            return Created("", factuur);
        }

        [HttpPut]
        public ActionResult<Factuur> UpdateFactuur([FromBody] Factuur factuur)
        {
            var updatedFactuur = _factuurFacade.UpdateFactuur(factuur);
            if (updatedFactuur == null)
                return Conflict();
            return updatedFactuur;
        }
    }
}