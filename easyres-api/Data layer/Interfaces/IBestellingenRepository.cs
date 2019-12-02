using Data_layer.Model;
using System.Collections.Generic;

namespace Data_layer.Interfaces
{
    public interface IBestellingenRepository
    {
        void SaveChanges();
        List<Bestelling> GetBestellingenForRestaurant(long idRes);
        Bestelling AddBestelling(long idRes, string idGebruiker, Bestelling bestelling);
        Bestelling UpdateBestelling(Bestelling bestelling);
        List<Bestelling> GetBestellingenBar(long idRes);
        List<Bestelling> GetBestellingenKeuken(long idRes);
        Bestelling GetBestellingRestaurantByID(long idRes, long idBestel);
        Bestelling UpdateBestellingen(Bestelling bestelling, long idRes);
        List<Bestelling> GetBestellingenGebruiker(string idGebruiker, long idRes);
    }
}
