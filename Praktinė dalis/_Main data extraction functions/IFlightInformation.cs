namespace MainDataExtractionFunctions
{
    using System;
    public interface IFlightInformation
    {
        string Origin { get; set; }
        string Destination { get; set; }
        string DepartureDateTimeString { get; set; }
        string ArrivalDateTimeString { get; set; }
        DateTime DepartureDateTime { get; set; }
        DateTime ArrivalDateTime { get; set; }
        string Currency { get; set; }
        string FareFamily { get; set; }
        string CarrierCode { get; set; }
        string FlightNumber { get; set; }
        decimal? FullPrice { get; set; }
        decimal? Taxes { get; set; }
        int? Seats { get; set; }
    }
}