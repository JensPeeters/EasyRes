using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_layer.Model
{
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        public List<Product> Voorgerechten { get; set; }
        public List<Product> Hoofdgerechten { get; set; }
        public List<Product> Dranken { get; set; }
        public List<Product> Desserts { get; set; }
    }
}
