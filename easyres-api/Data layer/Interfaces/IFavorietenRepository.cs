using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
