using Data_layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer.Interfaces
{
    public interface IFactuurFacade
    {
        Factuur GetFactuur(string idGebruiker, long idRes);
        List<Factuur> GetFacturen(string idGebruiker);
        Factuur GetFactuurById(string idGebruiker, long idFactuur);
        Factuur GenerateFactuur(string idGebruiker, long idRes, string mail);

        Factuur UpdateFactuur(Factuur factuur);
    }
}
