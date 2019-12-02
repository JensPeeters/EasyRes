using Business_layer.Interfaces;
using Data_layer.Interfaces;
using Data_layer.Model;
using System;
using System.Collections.Generic;

namespace Business_layer.Facades
{
    public class SessieFacade : ISessieFacade
    {
        private readonly ISessieRepository _sessieRepository;

        public SessieFacade(ISessieRepository sessieRepository)
        {
            this._sessieRepository = sessieRepository;
        }
        public Sessie CreateSession(string userId, int restaurantId, int tafelNr)
        {
            var sessie = _sessieRepository.CreateSession(userId, restaurantId, tafelNr);
            try
            {
                _sessieRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return sessie;
        }

        public List<Sessie> GetSessionsByUserId(string userId)
        {
            return _sessieRepository.GetSessionsByUserId(userId);
        }
    }
}
