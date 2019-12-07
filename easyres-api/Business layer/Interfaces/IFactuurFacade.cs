using Data_layer.Model;
using System.Collections.Generic;

namespace Business_layer.Interfaces
{
    public interface IFactuurFacade
    {
        Factuur GetFactuur(string idGebruiker, long idRes);
        List<Factuur> GetFacturen(string idGebruiker, string sortBy);
        Factuur GetFactuurById(string idGebruiker, long idFactuur);
        Factuur GenerateFactuur(string idGebruiker, long idRes, string mail);

        List<Factuur> GetFacturenRestaurant(int idRes);

        Factuur UpdateFactuur(Factuur factuur);
    }
}
