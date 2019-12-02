using Data_layer.Model;
using System.Collections.Generic;

namespace Data_layer.Interfaces
{
    public interface IReserveringenRepository
    {
        void SaveChanges();
        List<Reservatie> GetReserveringen(string userid);
        List<Reservatie> GetPastReserveringen(string userid);
        Reservatie GetReservatie(long id);
        Reservatie DeleteReservatie(long id, string user = "gebruiker");
    }
}
