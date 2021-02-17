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

        public string FlightKey;
        public Flight(string origin, string destination, string[] fullDate, string flightNumber, string[][] flightInfo, string flightKey)
        {
            Origin = origin;
            Destination = destination;

            FlightNumber = flightNumber;

            if(DateTime.TryParseExact(fullDate.First(), "yyyy-ddd dd, MMM-h:mmtt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime departureTime))
            {
                DepartureTime = departureTime;
            }

            if (DateTime.TryParseExact(fullDate.Last(), "yyyy-ddd dd, MMM-h:mmtt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime arrivalTime))
            {
                ArrivalTime = arrivalTime;
            }

            if (decimal.TryParse(flightInfo.First()[2], out decimal fullPrice))
            {
                FullPrice = fullPrice;
            }

            FareFamily = flightInfo.First()[0];
            Currency = flightInfo.First()[1];

            TravelDuration = ArrivalTime.Subtract(DepartureTime).ToString();

            FlightKey = flightKey;
        }
    }
}
