using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Reservatie
    {
        [Key]
        public int ReservatieId { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string Datum { get; set; }
        public int AantalPersonen { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
