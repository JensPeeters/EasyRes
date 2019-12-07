using Business_layer.Interfaces;
using Business_layer.Services;
using Data_layer.Interfaces;
using Data_layer.Model;
using System;
using System.Collections.Generic;

namespace Business_layer.Facades
{
    public class ReserveringenFacade : IReserveringenFacade
    {
        SendGridEmailSender emailSender;
        private readonly IReserveringenRepository _reserveringRepository;

        public ReserveringenFacade(IReserveringenRepository reserveringRepository)
        {
            this._reserveringRepository = reserveringRepository;
            this.emailSender = new SendGridEmailSender();
        }
        public List<Reservatie> GetReserveringen(string userid, string sortBy)
        {
            return _reserveringRepository.GetReserveringen(userid, sortBy);
        }
        public List<Reservatie> GetPastReserveringen(string userid, string sortBy)
        {
            return _reserveringRepository.GetPastReserveringen(userid, sortBy);
        }
        public Reservatie GetReservatie(long id)
        {
            return _reserveringRepository.GetReservatie(id);
        }
        public Reservatie DeleteReservatie(long id, string user = "gebruiker")
        {
            var verwijderdeReservatie = _reserveringRepository.DeleteReservatie(id, user);
            if (DateTime.ParseExact(verwijderdeReservatie.Datum, "yyyy-MM-dd", null) < DateTime.Now)
            {
                verwijderdeReservatie.Naam = "PAST";
                return verwijderdeReservatie;
            }
            if (verwijderdeReservatie != null)
            {
                _reserveringRepository.SaveChanges();
                string enter = "<br>";
                string mailmsg;
                switch (user)
                {
                    case "gebruiker":
                        mailmsg =
                        "Beste " + verwijderdeReservatie.Naam + "," +
                        enter +
                        enter +
                        "Hierbij een bevestiging van uw geannuleerde reservatie met onderstaande gegevens." +
                        enter +
                        enter +
                        "<ul>" +
                        "<li> Op naam van: " + verwijderdeReservatie.Naam + "</li>" +
                        "<li> Bij restaurant: " + verwijderdeReservatie.Restaurant.Naam + "</li>" +
                        "<li> Aantal personen: " + verwijderdeReservatie.AantalPersonen + "</li>" +
                        "<li> Gepland op: " + verwijderdeReservatie.Datum + " om " + verwijderdeReservatie.Tijdstip + "</li>" +
                        "<li> Email adres: " + verwijderdeReservatie.Email + "</li>" +
                        "<li> Telefoonnummer: " + verwijderdeReservatie.TelefoonNummer.ToString() + "</li>" +
                        "</ul>";
                        break;
                    case "uitbater":
                        mailmsg =
                        "Beste " + verwijderdeReservatie.Naam + "," +
                        enter +
                        enter +
                        "Het restaurant waarbij u een reservatie maakt heeft uw reservatie met onderstaande gegevens geannuleerd." +
                        enter +
                        "Als dit onverwachts is, gelieve contact op te nemen met het restaurant." +
                        enter +
                        enter +
                        "<ul>" +
                        "<li> Op naam van: " + verwijderdeReservatie.Naam + "</li>" +
                        "<li> Bij restaurant: " + verwijderdeReservatie.Restaurant.Naam + "</li>" +
                        "<li> Aantal personen: " + verwijderdeReservatie.AantalPersonen + "</li>" +
                        "<li> Gepland op: " + verwijderdeReservatie.Datum + " om " + verwijderdeReservatie.Tijdstip + "</li>" +
                        "<li> Email adres: " + verwijderdeReservatie.Email + "</li>" +
                        "<li> Telefoonnummer: " + verwijderdeReservatie.TelefoonNummer.ToString() + "</li>" +
                        "</ul>";
                        break;
                    default:
                        return null;
                }
                emailSender.SendEmailAsync(verwijderdeReservatie.Email, "Annulatie van uw reservatie.", mailmsg).Wait();
            }
            return verwijderdeReservatie;
        }
    }
}
