using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data_layer.Model
{
    public class User
    {
        [Key]
        public string GebruikersID { get; set; }
    }
}
