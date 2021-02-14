namespace StarPeru
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
        public decimal? FullPrice;
        public decimal? Taxes;

        public string FareFamily;
        public string FlightNumber;
        public string Currency;

        public DateTime DepartureTime;
        public DateTime ArrivalTime;

        public string TravelDuration;

        public string FlightCode;

        public Flight(string[][] sectorOriginAndDestination, string[] sectorInfo, string flightCode)
        {
            Origin = sectorOriginAndDestination.First().First();
            Destination = sectorOriginAndDestination.First().Last();

            FareFamily = sectorInfo[0];
            if (Decimal.TryParse(sectorInfo[1], out decimal priceWithoutTaxes))
            {
                PriceWithoutTaxes = priceWithoutTaxes;
            }
            FlightNumber = sectorInfo[2];
   
            if (DateTime.TryParseExact(sectorInfo[3] + " " + sectorInfo[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime departureDate))
            {
                DepartureTime = departureDate;
            }
            if (DateTime.TryParseExact(sectorInfo[5] + " " + sectorInfo[6], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime arrivalDate))
            {
                ArrivalTime = arrivalDate;
            }

            Currency = sectorInfo[7];

            FlightCode = flightCode;
        }
    }
}
