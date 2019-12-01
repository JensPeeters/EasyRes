using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETAcademyServer.Services;
using easyres_api.Model;
using easyres_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace easyres_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactuurController : ControllerBase
    {
        PDFGenerator pdfGenerator;
        DatabaseContext context;
        SendGridEmailSender emailSender;
        public FactuurController(DatabaseContext ctx)
        {
            this.context = ctx;
            this.pdfGenerator = new PDFGenerator();
            this.emailSender = new SendGridEmailSender();
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

        [Route("{idGebruiker}")]
        [HttpGet]
        public ActionResult<List<Factuur>> GetFacturen(string idGebruiker)
        {
            Gebruiker gebruiker = context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            if (gebruiker == null)
                return NotFound();
            List<Factuur> facturen = context.Facturen
                                            .Include(a => a.Producten)
                                            .Include(a => a.Restaurant)
                                            .Where(a => a.Gebruiker == gebruiker).ToList();
            if (facturen == null)
                return NotFound();
            return facturen;
        }

        [Route("{idGebruiker}/factuur/{idFactuur}")]
        [HttpGet]
        public ActionResult<Factuur> GetFactuurById(string idGebruiker, long idFactuur)
        {
            Gebruiker gebruiker = context.Gebruikers.Where(a => a.GebruikersID == idGebruiker).FirstOrDefault();
            if (gebruiker == null)
                return NotFound();
            Factuur factuur = context.Facturen
                                     .Include(a => a.Producten)
                                     .Include(a => a.Restaurant)
                                     .Where(a => a.Gebruiker == gebruiker)
                                     .Where(a => a.Id == idFactuur).LastOrDefault();
            if (factuur == null)
                return NotFound();
            return factuur;
        }

        [Route("{idGebruiker}/{idRes}/{mail}")]
        [HttpPost]
        public ActionResult<Factuur> GenerateFactuur(string idGebruiker, long idRes, string mail)
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

            Factuur factuur = new Factuur()
            {
                Gebruiker = gebruiker,
                Restaurant = restaurant,
                Producten = producten,
                Datum = DateTime.Now,
                Betaald = false
            };
            context.Facturen.Add(factuur);
            context.SaveChanges();
            /*pdfGenerator.GeneratePDF(factuur);
            if (gebruiker.GetFactuurByEmail)
            {
                //Normaal stuur je de renderer niet mee
                string msg = "In bijlage vindt u de factuur van u bezoek aan " + factuur.Restaurant.Naam + ".";
                //emailSender.SendEmailAsync(mail,
                //                           "Factuur van " + factuur.Restaurant.Naam,
                //                           msg).Wait();
                emailSender.SendEmailAsync(mail,
                "Factuur van " + factuur.Restaurant.Naam,
                                           msg, factuur.Id, pdfGenerator.GetStream()).Wait();
            }*/
            return Created("", factuur);
        }

        [HttpPut]
        public ActionResult<Factuur> UpdateFactuur([FromBody] Factuur factuur)
        {
            Factuur UpdateFactuur  = context.Facturen.Where(a => a.Id == factuur.Id).FirstOrDefault();
            if (UpdateFactuur == null)
                return NotFound();
            UpdateFactuur.Betaald = factuur.Betaald;
            context.SaveChanges();
            return Ok(UpdateFactuur);
        }
    }
}