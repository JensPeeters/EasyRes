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
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            this._userFacade = userFacade;
        }

        [Route("{userType}/{userId}")]
        [HttpPost]
        public ActionResult<User> CreateUser(string userType, string userId)
        {
            var user = _userFacade.CreateUser(userType, userId);
            if (user == null)
                NotFound();
            return user;
        }

        [Route("isgebruiker/{userId}")]
        [HttpGet]
        public ActionResult<Gebruiker> IsGebruiker(string userId)
        {
            var gebruiker = _userFacade.IsGebruiker(userId);
            if (gebruiker != null)
                return gebruiker;
            return NotFound();
        }

        [Route("isuitbater/{userId}")]
        [HttpGet]
        public ActionResult<Uitbater> IsUitbater(string userId)
        {
            var uitbater = _userFacade.IsUitbater(userId);
            if (uitbater != null)
                return uitbater;
            return NotFound();
        }
        [Route("{userId}")]
        [HttpPut]
        public ActionResult<User> UpdateGebruiker(string userId, [FromBody] Gebruiker updateGebruiker)
        {
            var gebruiker = _userFacade.IsGebruiker(userId);

            if (gebruiker == null)
            {
                var uitbater = _userFacade.IsUitbater(userId);
                if (uitbater == null)
                {
                    return NotFound($"De gebruiker is niet gevonden.");
                }
                else
                {
                    return NotFound($"Een uitbater kan deze instelling niet gebruiken.");
                }
            }
            try
            {
                _userFacade.UpdateGebruiker(userId, updateGebruiker);
            }
            catch (Exception)
            {
                return Conflict();
            }
            return gebruiker;
        }
    }
}