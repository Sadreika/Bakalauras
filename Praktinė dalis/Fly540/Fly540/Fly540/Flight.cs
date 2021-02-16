namespace Fly540
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class Flight
    {
        public string Origin;
        public string Destination;
        public string Connection;

        public decimal? PriceWithoutTaxes;
        public decimal? Taxes = 0;
        public decimal? FullPrice;

        public string FareFamily;
        public string FlightNumber;
        public string Currency;

        public DateTime DepartureTime;
        public DateTime ArrivalTime;

        public string Class;

        public string TravelDuration;

        public string FlightCode;

        public string FlightKey;

        public Flight(string[][] flightInfo, string flightKey)
        {
            if (decimal.TryParse(flightInfo.First()[3], out decimal fullPrice))
            {
                FullPrice = fullPrice;
            }

            FareFamily = flightInfo.First()[2];
            Currency = flightInfo.First()[1];
            Class = flightInfo.First()[0];

            FlightKey = flightKey;
        }
    }
}
