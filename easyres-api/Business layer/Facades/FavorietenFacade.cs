using Business_layer.Interfaces;
using Data_layer.Interfaces;
using Data_layer.Model;

namespace Business_layer.Facades
{
    public class FavorietenFacade : IFavorietenFacade
    {
        private readonly IFavorietenRepository _favorietRepository;

        public FavorietenFacade(IFavorietenRepository favorietRepository)
        {
            this._favorietRepository = favorietRepository;
        }
        public Gebruiker GetFavorieteRestaurants(string gebruikersId, string naam)
        {
            return _favorietRepository.GetFavorieteRestaurants(gebruikersId, naam);
        }

        public Gebruiker AddFavorieteRestaurant(string gebruikersId, long restaurantId)
        {
            var gebruiker = _favorietRepository.AddFavorieteRestaurant(gebruikersId, restaurantId);
            _favorietRepository.SaveChanges();
            return gebruiker;
        }

        public Gebruiker DeleteFavoriet(string gebruikersId, long restaurantId)
        {
            var gebruiker = _favorietRepository.DeleteFavoriet(gebruikersId, restaurantId);
            _favorietRepository.SaveChanges();
            return gebruiker;
        }
    }
}
