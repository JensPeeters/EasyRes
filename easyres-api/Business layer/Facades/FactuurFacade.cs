using Business_layer.Interfaces;
using Business_layer.Services;
using Data_layer.Interfaces;
using Data_layer.Model;
using System;
using System.Collections.Generic;

namespace Business_layer.Facades
{
    public class FactuurFacade : IFactuurFacade
    {

        //PDFGenerator pdfGenerator;
        //SendGridEmailSender emailSender;
        private readonly IFactuurRepository _factuurRepository;
        private readonly ISessieRepository _sessieRepository;
        private readonly IBestellingenRepository _bestellingenRepository;

        public FactuurFacade(IFactuurRepository factuurRepository, ISessieRepository sessieRepository, IBestellingenRepository bestellingenRepository)
        {
            //this.pdfGenerator = new PDFGenerator();
            //this.emailSender = new SendGridEmailSender();
            this._factuurRepository = factuurRepository;
            this._sessieRepository = sessieRepository;
            this._bestellingenRepository = bestellingenRepository;
        }
        public Factuur GetFactuur(string idGebruiker, long idRes)
        {
            var factuur = _factuurRepository.GetFactuur(idGebruiker, idRes);
            return factuur;
        }

        public List<Factuur> GetFacturen(string idGebruiker, string sortBy)
        {
            var facturen = _factuurRepository.GetFacturen(idGebruiker, sortBy);
            return facturen;
        }

        public Factuur GetFactuurById(string idGebruiker, long idFactuur)
        {
            var factuur = _factuurRepository.GetFactuurById(idGebruiker, idFactuur);
            return factuur;
        }
        public List<Factuur> GetFacturenRestaurant(int idRes)
        {
            var facturen = _factuurRepository.GetFacturenRestaurant(idRes);
            return facturen;
        }

        public Factuur GenerateFactuur(string idGebruiker, long idRes, string mail)
        {
            var factuur = _factuurRepository.GenerateFactuur(idGebruiker, idRes, mail);
            _sessieRepository.DeleteSessie(idGebruiker, idRes);
            _bestellingenRepository.DeleteBestellingen(idGebruiker, idRes);
            try
            {
                _factuurRepository.SaveChanges();
                _sessieRepository.SaveChanges();
                _bestellingenRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

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
            return factuur;
        }

        public Factuur UpdateFactuur(Factuur factuur)
        {
            var updatedFactuur = _factuurRepository.UpdateFactuur(factuur);
            try
            {
                _factuurRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return updatedFactuur;
        }
    }
}
