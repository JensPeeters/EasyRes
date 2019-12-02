using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_layer.Interfaces
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetRestaurants(IQueryFilter filter);

        List<Restaurant> GetGeadverteerdeRestaurant();

        Restaurant GetGeadverteerdeRestaurantBySoort(string soort);
        void SaveChanges();

        Restaurant UpdateGeadverteerdeRestaurantBySoort(Restaurant restaurant);

        Restaurant GetRestaurant(long id);

        Restaurant UpdateRestaurant(Restaurant updatedRestaurant, long id);

        Reservatie AddReservatie(Reservatie reservatie);
    
    }
}
