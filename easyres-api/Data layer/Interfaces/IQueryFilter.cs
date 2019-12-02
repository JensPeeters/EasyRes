namespace Data_layer.Interfaces
{
    public interface IQueryFilter
    {
        string Naam { get; set; }
        string Gemeente { get; set; }
        string Land { get; set; }
        string Type { get; set; }
        string Soort { get; set; }
        string Gerechten { get; set; }
        string SortBy { get; set; }
        string Direction { get; set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}
