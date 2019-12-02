using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_layer.Interfaces
{
    public interface IUserRepository
    {
        User CreateUser(string userType, string userId);

        Gebruiker IsGebruiker(string userId);

        Uitbater IsUitbater(string userId);
        User UpdateGebruiker(string userId, Gebruiker updateGebruiker);
        void SaveChanges();
    }
}
