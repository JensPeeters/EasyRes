using Data_layer.Model;

namespace Business_layer.Interfaces
{
    public interface IFavorietenFacade
    {
        Gebruiker GetFavorieteRestaurants(string gebruikersId, string naam);
        Gebruiker AddFavorieteRestaurant(string gebruikersId, long restaurantId);
        Gebruiker DeleteFavoriet(string gebruikersId, long restaurantId);
    }
}
