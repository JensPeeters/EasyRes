using easyres_api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using easyres_api.Services;

namespace easyres_api.Controllers
{
    [Route("api/reservatie")]
    [ApiController]
    public class ReserveringController : ControllerBase
    {
        DatabaseContext context;
        SendGridEmailSender emailSender = new SendGridEmailSender();

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
        public ActionResult<Reservatie> DeleteReservatie(long id, string user = "gebruiker")
        {
            var reservatie = context.Reservaties.Where(a => a.ReservatieId == id)
                                                .Include(a => a.Restaurant)
                                                .FirstOrDefault();
            
            if (reservatie == null)
            return NotFound();

            context.Reservaties.Remove(reservatie);
            context.SaveChanges();

            string enter = "<br>";
            string mailmsg;
            if (user == "gebruiker")
            {
                mailmsg =
                "Beste " + reservatie.Naam + "," +
                enter +
                enter +
                "Hierbij een bevestiging van uw geannuleerde reservatie met onderstaande gegevens." +
                enter +
                enter +
                "<ul>" +
                "<li> Op naam van: " + reservatie.Naam + "</li>" +
                "<li> Bij restaurant: " + reservatie.Restaurant.Naam + "</li>" +
                "<li> Aantal personen: " + reservatie.AantalPersonen + "</li>" +
                "<li> Gepland op: " + reservatie.Datum + " om " + reservatie.Tijdstip + "</li>" +
                "<li> Email adres: " + reservatie.Email + "</li>" +
                "<li> Telefoonnummer: " + reservatie.TelefoonNummer.ToString() + "</li>" +
                "</ul>" +
                enter +
                "Mogelijk gemaakt door EasyRes™";
            }
            else if (user == "uitbater")
            {
                mailmsg =
                "Beste " + reservatie.Naam + "," +
                enter +
                enter +
                "Het restaurant waarbij u een reservatie maakt heeft uw reservatie met onderstaande gegevens geannuleerd." +
                enter +
                "Als dit onverwachts is, gelieve contact op te nemen met het restaurant." +
                enter +
                enter +
                "<ul>" +
                "<li> Op naam van: " + reservatie.Naam + "</li>" +
                "<li> Bij restaurant: " + reservatie.Restaurant.Naam + "</li>" +
                "<li> Aantal personen: " + reservatie.AantalPersonen + "</li>" +
                "<li> Gepland op: " + reservatie.Datum + " om " + reservatie.Tijdstip + "</li>" +
                "<li> Email adres: " + reservatie.Email + "</li>" +
                "<li> Telefoonnummer: " + reservatie.TelefoonNummer.ToString() + "</li>" +
                "</ul>" +
                enter +
                "Mogelijk gemaakt door EasyRes™";
            }
            else
            {
                return NotFound();
            }

            emailSender.SendEmailAsync(reservatie.Email, "Annulatie van uw reservatie.", mailmsg).Wait();
            return NoContent();
        }
    }
}