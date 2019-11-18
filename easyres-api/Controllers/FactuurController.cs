﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using easyres_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactuurController : ControllerBase
    {
        DatabaseContext context;
        public FactuurController(DatabaseContext ctx)
        {
            this.context = ctx;
        }

        [Route("{idGebruiker}/{idRes}")]
        [HttpGet]
        public ActionResult<Factuur> GetFactuur(string idGebruiker, long idRes)
        {
            Gebruiker gebruiker = context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            Restaurant restaurant = context.Restaurants.Where(a => a.RestaurantId == idRes).FirstOrDefault();
            if (gebruiker == null || restaurant == null)
                return NotFound();
            Factuur factuur = context.Facturen
                                     .Include(a => a.Producten)
                                     .Include(a => a.Restaurant)
                                     .Where(a => a.Restaurant == restaurant)
                                     .Where(a => a.Gebruiker == gebruiker).LastOrDefault();
            if (factuur == null)
                return NotFound();
            return factuur;
        }

        [Route("{idGebruiker}/{idRes}")]
        [HttpPost]
        public ActionResult<Factuur> GenerateFactuur(string idGebruiker, long idRes)
        {
            Gebruiker gebruiker = context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            Restaurant restaurant = context.Restaurants.Where(a => a.RestaurantId == idRes).FirstOrDefault();
            if (gebruiker == null || restaurant == null)
                return NotFound();
            List<Bestelling> Bestellingen = context.Bestellingen
                                        .Include(a => a.Etenswaren)
                                        .Include(a => a.Dranken)
                                        .Where(a => a.Restaurant == restaurant)
                                        .Where(a => a.Gebruiker == gebruiker).ToList();
            List<Product> producten = new List<Product>();
            foreach (var bestelling in Bestellingen)
            {
                foreach (Product eten in bestelling.Etenswaren)
                {
                    CheckList(eten);

                }
                foreach (Product drinken in bestelling.Dranken)
                {
                    CheckList(drinken);
                }
            }

            void CheckList(Product product)
            {
                var tempProduct = producten.Find(a => a.Naam == product.Naam);
                if (tempProduct == null)
                {
                    producten.Add(product);
                }
                else
                {
                    tempProduct.Aantal += product.Aantal;
                    producten.Find(a => a.Naam == product.Naam).Aantal = tempProduct.Aantal;
                }
            }

            Factuur factuur = new Factuur() {
                Gebruiker = gebruiker,
                Restaurant = restaurant,
                Producten = producten,
                Datum = DateTime.Now,
                Betaald = false
            };
            
            context.Facturen.Add(factuur);
            context.SaveChanges();
            return Created("", factuur);
        }
    }
}