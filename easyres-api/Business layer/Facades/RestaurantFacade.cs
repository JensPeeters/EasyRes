using Business_layer.Exceptions;
using Business_layer.Interfaces;
using Business_layer.Services;
using Data_layer.Interfaces;
using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer.Facades
{
    public class RestaurantFacade : IRestaurantFacade
    {
        SendGridEmailSender emailSender;
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantFacade(IRestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
            this.emailSender = new SendGridEmailSender();
        }
        public List<Restaurant> GetRestaurants(IQueryFilter filter)
        {
            return _restaurantRepository.GetRestaurants(filter);
        }

        public List<Restaurant> GetGeadverteerdeRestaurant()
        {
            return _restaurantRepository.GetGeadverteerdeRestaurant();
        }

        public Restaurant GetGeadverteerdeRestaurantBySoort(string soort)
        {
            return _restaurantRepository.GetGeadverteerdeRestaurantBySoort(soort);
        }

        public Restaurant UpdateGeadverteerdeRestaurantBySoort(Restaurant restaurant)
        {
            try
            {
                _restaurantRepository.UpdateGeadverteerdeRestaurantBySoort(restaurant);
                _restaurantRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return restaurant;
        }

        public Restaurant GetRestaurant(long id)
        {
            return _restaurantRepository.GetRestaurant(id);
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant, long id)
        {
            var updatedRestaurant = _restaurantRepository.UpdateRestaurant(restaurant, id);
            try
            {
                _restaurantRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return updatedRestaurant;
        }

        public Reservatie AddReservatie(Reservatie reservatie)
        {
            var createdReservatie = _restaurantRepository.AddReservatie(reservatie);
            if (createdReservatie == null)
                throw new RestaurantVolzetException();
            try
            {
                _restaurantRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            string mailmsg = CreateMailMessage(createdReservatie);
            emailSender.SendEmailAsync(createdReservatie.Email, "Bevestiging van uw reservatie.", mailmsg).Wait();
            return createdReservatie;
        }

        private static string CreateMailMessage(Reservatie createdReservatie)
        {
            string enter = "<br>";
            string mailmsg =
                "Beste " + createdReservatie.Naam + "," +
                enter +
                enter +
                "Bedankt voor uw reservering! Wij verzoeken u vriendelijk om de onderstaande" + enter +
                "reserveringsgegevens te controleren:" +
                enter +
                "<ul>" +
                "<li> Op naam van: " + createdReservatie.Naam + "</li>" +
                "<li> Bij restaurant: " + createdReservatie.Restaurant.Naam + "</li>" +
                "<li> Aantal personen: " + createdReservatie.AantalPersonen + "</li>" +
                "<li> Gepland op: " + createdReservatie.Datum + " om " + createdReservatie.Tijdstip + "</li>" +
                "<li> Email adres: " + createdReservatie.Email + "</li>" +
                "<li> Telefoonnummer: " + createdReservatie.TelefoonNummer.ToString() + "</li>" +
                "</ul>";
            return mailmsg;
        }
    }
}
