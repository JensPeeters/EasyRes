using Data_layer.Model;
using System.Collections.Generic;

namespace Data_layer.Interfaces
{
    public interface IReserveringenRepository
    {
        void SaveChanges();
        List<Reservatie> GetReserveringen(string userid, string sortBy);
        List<Reservatie> GetPastReserveringen(string userid, string sortBy);
        Reservatie GetReservatie(long id);
        Reservatie DeleteReservatie(long id, string user = "gebruiker");
    }
}
