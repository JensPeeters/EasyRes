﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class Openingsuren
    {
        [Key]
        public int ID { get; set; }
        public string Maandag { get; set; }
        public string Dinsdag { get; set; }
        public string Woensdag { get; set; }
        public string Donderdag { get; set; }
        public string Vrijdag { get; set; }
        public string Zaterdag { get; set; }
        public string Zondag { get; set; }
    }
}