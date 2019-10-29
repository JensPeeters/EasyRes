using System.ComponentModel.DataAnnotations;

namespace easyres_api.Model
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
