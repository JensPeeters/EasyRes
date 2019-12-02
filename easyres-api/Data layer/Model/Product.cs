using System.ComponentModel.DataAnnotations;

namespace Data_layer.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
    }
}
