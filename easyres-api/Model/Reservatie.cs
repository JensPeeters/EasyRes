using System.ComponentModel.DataAnnotations;

namespace easyres_api.Model
{
    public class Reservatie
    {
        [Key]
        public int ReservatieId { get; set; }
        public string UserId { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string Datum { get; set; }
        public string Tijdstip { get; set; }
        public int AantalPersonen { get; set; }
        public int TafelNr { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
