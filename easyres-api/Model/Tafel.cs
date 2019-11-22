using System.ComponentModel.DataAnnotations;

namespace easyres_api.Model
{
    public class Tafel
    {
        [Key]
        public int TafelID { get; set; }
        public int TafelNr { get; set; }
        public int Zitplaatsen { get; set; }
    }
}
