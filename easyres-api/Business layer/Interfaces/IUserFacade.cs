using Data_layer.Model;

namespace Business_layer.Interfaces
{
    public interface IUserFacade
    {
        User CreateUser(string userType, string userId);

        Gebruiker IsGebruiker(string userId);

        Uitbater IsUitbater(string userId);
        User UpdateGebruiker(string userId, Gebruiker updateGebruiker);
    }
}
