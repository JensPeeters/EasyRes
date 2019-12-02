using Business_layer.Interfaces;
using Data_layer.Interfaces;
using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public User CreateUser(string userType, string userId)
        {
            var user = _userRepository.CreateUser(userType, userId);
            try
            {
                _userRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return user;
        }
        public Gebruiker IsGebruiker(string userId)
        {
            return _userRepository.IsGebruiker(userId);
        }

        public Uitbater IsUitbater(string userId)
        {
            return _userRepository.IsUitbater(userId);
            
        }
        public User UpdateGebruiker(string userId, Gebruiker updateGebruiker)
        {
            var gebruiker = _userRepository.UpdateGebruiker(userId,updateGebruiker);
            try
            {
                _userRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return gebruiker;
        }
    }
}
