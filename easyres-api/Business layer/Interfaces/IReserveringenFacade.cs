using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer.Interfaces
{
    public interface IReserveringenFacade
    {
        List<Reservatie> GetReserveringen(string userid);
        Reservatie GetReservatie(long id);
        Reservatie DeleteReservatie(long id, string user = "gebruiker");
    }
}
