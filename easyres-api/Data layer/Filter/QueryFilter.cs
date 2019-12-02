using Data_layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_layer.Filter
{
    public class QueryFilter : IQueryFilter
    {
        public string Naam { get; set; }
        public string Gemeente { get; set; }
        public string Land { get; set; }
        public string Type { get; set; }
        public string Soort { get; set; }
        public string Gerechten { get; set; }
        public string SortBy { get; set; }
        public string Direction { get; set; } = "asc";
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 0;
    }
}
