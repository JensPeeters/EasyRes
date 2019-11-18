﻿using easyres_api.Model;
using easyres_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        DatabaseContext context;
        SendGridEmailSender emailSender = new SendGridEmailSender();

        public RestaurantController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [HttpGet]
        public List<Restaurant> GetRestaurants(string naam, string gemeente, string land, string type, string soort,
                                string gerechten, string sortBy, string direction = "asc",
                                int pageSize = 10, int pageNumber = 0)
        {
            IQueryable<Restaurant> query = context.Restaurants;
            if (!string.IsNullOrEmpty(naam))
            {
                query = query.Where(b => b.Naam.ToLower().Contains(naam.ToLower().Trim()));
            }
            if (!string.IsNullOrEmpty(land))
                query = query.Where(b => b.Locatie.Land.ToLower().Contains(land.ToLower().Trim()));
            if (!string.IsNullOrEmpty(gemeente))
                query = query.Where(b => b.Locatie.Gemeente.ToLower().Contains(gemeente.ToLower().Trim()));
            if (!string.IsNullOrEmpty(type))
                query = query.Where(b => b.Type == type);
            if (!string.IsNullOrEmpty(soort))
                query = query.Where(b => b.Soort == soort);
            if (!string.IsNullOrEmpty(gerechten))
            {
                var spliString = gerechten.Split(",");
                foreach (string item in spliString)
                {
                    query = query.Where(b => b.Gerechten.ToLower().Contains(item.ToLower().Trim()));
                }
            }
                

            if (string.IsNullOrEmpty(sortBy)) sortBy = "default";
            switch (sortBy.ToLower())
            {
                case "naam":
                    if (direction == "asc")
                        query = query.OrderBy(b => b.Naam);
                    else
                        query = query.OrderByDescending(b => b.Naam);
                    break;
                case "gemeente":
                    if (direction == "asc")
                        query = query.OrderBy(b => b.Locatie.Gemeente);
                    else
                        query = query.OrderByDescending(b => b.Locatie.Gemeente);
                    break;
                case "type":
                    if (direction == "asc")
                        query = query.OrderBy(b => b.Type);
                    else
                        query = query.OrderByDescending(b => b.Type);
                    break;
                case "soort":
                    if (direction == "asc")
                        query = query.OrderBy(b => b.Soort);
                    else
                        query = query.OrderByDescending(b => b.Soort);
                    break;
                case "land":
                    if (direction == "asc")
                        query = query.OrderBy(b => b.Locatie.Land);
                    else
                        query = query.OrderByDescending(b => b.Locatie.Land);
                    break;
                default:
                    if (direction == "asc")
                        query = query.OrderBy(b => b.RestaurantId);
                    else
                        query = query.OrderByDescending(b => b.RestaurantId);
                    break;
            }
            query = query.Skip(pageNumber * pageSize);
            if (pageSize > 25) pageSize = 25;
            if (pageSize <= 0) pageSize = 10;
            query = query.Take(pageSize);
            return query.ToList();
        }

        [Route("advertentie")]
        [HttpGet]
        public ActionResult<List<Restaurant>> GetGeadverteerdeRestaurant()
        {
            var geadverteerdeRestaurants = context.Restaurants
                                        .Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .Where(a => a.IsAdvertentie == true).ToList();
            if (geadverteerdeRestaurants == null)
                return NotFound();
            return geadverteerdeRestaurants;
        }

        [Route("advertentie/{soort}")]
        [HttpGet]
        public ActionResult<Restaurant> GetGeadverteerdeRestaurantBySoort(string soort)
        {
            var geadverteerdRestaurant = context.Restaurants
                                        .Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .Where(a => a.IsAdvertentie == true)
                                        .FirstOrDefault(a => a.Soort == soort);
            if (geadverteerdRestaurant == null)
                return NotFound();
            return geadverteerdRestaurant;
        }

        [Route("advertentie")]
        [HttpPut]
        public ActionResult<Restaurant> UpdateGeadverteerdeRestaurantBySoort([FromBody] Restaurant restaurant)
        {
            var oudeAdvertentie = context.Restaurants
                .Where(a => a.IsAdvertentie == true)
                .FirstOrDefault(a => a.Soort == restaurant.Soort);
            if(oudeAdvertentie != null)
            {
                oudeAdvertentie.IsAdvertentie = false;
            }
            restaurant.IsAdvertentie = true;
            try
            {
                context.Restaurants.Update(restaurant);
                context.SaveChanges();
            }
            catch (System.Exception e)
            {

                throw new System.Exception(e.Message);
            }
            return Ok(restaurant);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Restaurant> GetAdvertentie(long id)
        {
            var restaurant = context.Restaurants.Where(a => a.RestaurantId == id).Include(a => a.Menu)
                                        .Include(a => a.Openingsuren)
                                        .Include(a => a.Locatie)
                                        .Include(a => a.Menu.Desserts)
                                        .Include(a => a.Menu.Dranken)
                                        .Include(a => a.Menu.Hoofdgerechten)
                                        .Include(a => a.Menu.Voorgerechten)
                                        .FirstOrDefault();
            if (restaurant == null)
                return NotFound();
            return restaurant;
        }

        [Route("{id}/reservatie")]
        [HttpGet]
        public List<Reservatie> GetRestaurantReservations(long id)
        {
            var restaurant = context.Restaurants.Include(a => a.Reservaties)
                                                .Include(a => a.Menu)
                                                .Include(a => a.Menu.Desserts)
                                                .Include(a => a.Menu.Dranken)
                                                .Include(a => a.Menu.Hoofdgerechten)
                                                .Include(a => a.Menu.Voorgerechten)
                                                .Include(a => a.Locatie)
                                                .SingleOrDefault(a => a.RestaurantId == id);
            return restaurant.Reservaties;
        }

        [Route("{id}/reservatie")]
        [HttpPost]
        public ActionResult<Reservatie> AddReservatie([FromBody] Reservatie reservatie)
        {
            var restaurant = context.Restaurants.Include(a => a.Menu)
                                                .Include(a => a.Menu.Desserts)
                                                .Include(a => a.Menu.Dranken)
                                                .Include(a => a.Menu.Hoofdgerechten)
                                                .Include(a => a.Menu.Voorgerechten)
                                                .Include(a => a.Reservaties)
                                                .Include(a => a.Openingsuren)
                                                .Include(a => a.Locatie)
                                                .Include(a => a.Locatie)
                                                .SingleOrDefault(a => a.RestaurantId == reservatie.Restaurant.RestaurantId);

            Reservatie finalReservatie = new Reservatie();

            finalReservatie.UserId = reservatie.UserId;
            finalReservatie.Naam = reservatie.Naam;
            finalReservatie.Email = reservatie.Email;
            finalReservatie.TelefoonNummer = reservatie.TelefoonNummer;
            finalReservatie.Datum = reservatie.Datum;
            finalReservatie.Tijdstip = reservatie.Tijdstip;
            finalReservatie.AantalPersonen = reservatie.AantalPersonen;
            finalReservatie.Restaurant = reservatie.Restaurant;
            restaurant.Reservaties.Add(finalReservatie);
            context.Restaurants.Update(restaurant);
            context.SaveChanges();
            string enter = "<br>";
            string mailmsg =
                "Beste " + reservatie.Naam + "," +
                enter +
                enter +
                "Bedankt voor uw reservering! Wij verzoeken u vriendelijk om de onderstaande" + enter +
                "reserveringsgegevens te controleren:" +
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

            emailSender.SendEmailAsync(finalReservatie.Email, "Bevestiging van uw reservatie.", mailmsg).Wait();
            return Created("", reservatie);
        }


    }
}