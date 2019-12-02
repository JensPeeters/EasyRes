using System.ComponentModel.DataAnnotations;

namespace Data_layer.Model
{
    public class Sessie
    {
        [Key]
        public int Id { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Restaurant Restaurant { get; set; }
        public int TafelNr { get; set; }

    }
}
