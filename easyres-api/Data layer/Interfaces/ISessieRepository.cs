using Data_layer.Model;
using System.Collections.Generic;

namespace Data_layer.Interfaces
{
    public interface ISessieRepository
    {
        Sessie CreateSession(string userId, int restaurantId, int tafelNr);
        void SaveChanges();

        List<Sessie> GetSessionsByUserId(string userId);
    }
}
