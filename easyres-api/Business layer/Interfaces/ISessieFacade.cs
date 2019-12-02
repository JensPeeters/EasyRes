using Data_layer.Model;
using System.Collections.Generic;

namespace Business_layer.Interfaces
{
    public interface ISessieFacade
    {
        Sessie CreateSession(string userId, int restaurantId, int tafelNr);
        List<Sessie> GetSessionsByUserId(string userId);
    }
}
