using Data_layer.Model;

namespace Data_layer.Interfaces
{
    public interface IFavorietenRepository
    {
        void SaveChanges();
        Gebruiker GetFavorieteRestaurants(string gebruikersId, string naam);
        Gebruiker AddFavorieteRestaurant(string gebruikersId, long restaurantId);
        Gebruiker DeleteReservatie(string gebruikersId, long restaurantId);
    }
}
