using System.ComponentModel.DataAnnotations;

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
