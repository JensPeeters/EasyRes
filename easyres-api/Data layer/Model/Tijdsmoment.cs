using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data_layer.Model
{
    public class Tijdsmoment
    {
        [Key]
        public int ID { get; set; }
        public string Datum { get; set; }
        public string Van { get; set; }
        public string Tot { get; set; }
    }
}
