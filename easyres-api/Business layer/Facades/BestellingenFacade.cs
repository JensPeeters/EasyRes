using Business_layer.Interfaces;
using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Business_layer.Facades
{
    public class BestellingenFacade : IBestellingenFacade
    {
        private readonly IBestellingenRepository _bestellingRepository;

        public BestellingenFacade(IBestellingenRepository bestellingRepository)
        {
            this._bestellingRepository = bestellingRepository;
        }
        public List<Bestelling> GetBestellingenForRestaurant(long idRes)
        {
            return _bestellingRepository.GetBestellingenForRestaurant(idRes);
        }
        public Bestelling AddBestelling(long idRes, string idGebruiker,Bestelling bestelling)
        {
            var createdBestelling = _bestellingRepository.AddBestelling(idRes, idGebruiker, bestelling);
            _bestellingRepository.SaveChanges();
            return createdBestelling;
        }

        public Bestelling UpdateBestelling(Bestelling bestelling)
        {
            var updatedBestelling = _bestellingRepository.UpdateBestelling(bestelling);
            _bestellingRepository.SaveChanges();
            return updatedBestelling;
        }

        public List<Bestelling> GetBestellingenBar(long idRes)
        {
            return _bestellingRepository.GetBestellingenBar(idRes);
        }
        public List<Bestelling> GetBestellingenKeuken(long idRes)
        {
            return _bestellingRepository.GetBestellingenKeuken(idRes);
        }

        public Bestelling GetBestellingRestaurantByID(long idRes, long idBestel)
        {
            var bestelling = _bestellingRepository.GetBestellingRestaurantByID(idRes, idBestel);
            return bestelling;
        }

        public Bestelling UpdateBestellingen(Bestelling bestelling, long idRes)
        {
            var updatedBestelling = _bestellingRepository.UpdateBestellingen(bestelling, idRes);
            _bestellingRepository.SaveChanges();
            return updatedBestelling;
        }

        public List<Bestelling> GetBestellingenGebruiker(string idGebruiker, long idRes)
        {
            return _bestellingRepository.GetBestellingenGebruiker(idGebruiker, idRes);
        }
    }
}
