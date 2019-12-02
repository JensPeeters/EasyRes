using Data_layer.Interfaces;
using Data_layer.Model;
using System.Collections.Generic;

namespace Business_layer.Interfaces
{
    public interface IRestaurantFacade
    {
        List<Restaurant> GetRestaurants(IQueryFilter filter);
        List<Restaurant> GetGeadverteerdeRestaurant();
        Restaurant GetGeadverteerdeRestaurantBySoort(string soort);
        Restaurant UpdateGeadverteerdeRestaurantBySoort(Restaurant restaurant);
        Restaurant GetRestaurant(long id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant, long id);
        Reservatie AddReservatie(Reservatie reservatie);
    }
}
