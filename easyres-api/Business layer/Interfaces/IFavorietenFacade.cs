using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer.Interfaces
{
    public interface IFavorietenFacade
    {
        Gebruiker GetFavorieteRestaurants(string gebruikersId, string naam);
        Gebruiker AddFavorieteRestaurant(string gebruikersId, long restaurantId);
        Gebruiker DeleteReservatie(string gebruikersId, long restaurantId);
    }
}
