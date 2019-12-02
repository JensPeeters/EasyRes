using System.ComponentModel.DataAnnotations;

namespace Data_layer.Model
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
