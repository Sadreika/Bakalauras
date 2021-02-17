namespace MainDataExtractionFunctions
{
    public interface SearchCriteria
    {
        string Origin { get; set; }
        string Destination { get; set; }
        string DepartureYear { get; set; }
        string DepartureMonth { get; set; }
        string DepartureDay { get; set; }
        string ArrivalYear { get; set; }
        string ArrivalMonth { get; set; }
        string ArrivalDay { get; set; }
        string TravelType { get; set; }
        char Class { get; set; }
        string Connection { get; set; }
        string ConnectionCount { get; set; }
    }
}