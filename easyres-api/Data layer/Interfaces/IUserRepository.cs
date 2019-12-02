using Data_layer.Model;

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
