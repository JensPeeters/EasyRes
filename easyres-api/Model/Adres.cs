using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Adres
    {
        [Key]
        public int ID { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public string Land { get; set; }
        public int Straatnummer { get; set; }
        public string Bus { get; set; }
        public int Postcode { get; set; }
    }
}
