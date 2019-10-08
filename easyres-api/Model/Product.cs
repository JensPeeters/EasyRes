using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Product
    {
        [Key]
        public string Naam { get; set; }
        public double Prijs { get; set; }
    }
}
