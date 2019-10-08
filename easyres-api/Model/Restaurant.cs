using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Naam { get; set; }
        [Required]
        public Adres Locatie { get; set; }
        [Required]
        public Menu Menu { get; set; }
        public Openingsuren Openingsuren { get; set; }
        public string Beschrijving { get; set; }
        public string LogoImage { get; set; }
    }
}
