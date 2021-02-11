namespace StarPeru
{
    using System;
    using System.Globalization;
    public class Flight
    {
        public string Origin;
        public string Destination;

        public decimal FullPrice;
        public decimal PriceWithoutTaxes;
        public decimal Taxes;

        public string FareFamily;
        public string FlightNumber;
        public string CarrierCode;
        public int Seats;
        public string Currency;

        public DateTime DepartureTime;
        public DateTime ArrivalTime;

        public Flight(string[] sectorOriginAndDestination, string sectorInfo)
        {
            var a = 1;
            //try
            //{
            //    string[] originAndDestinationArray = sectorOriginAndDestination[0].Replace("&gt", "").Split(';');
            //    Origin = originAndDestinationArray[0];
            //    Destination = originAndDestinationArray[1];

            //    string[] flightInfo = sectorInfo.Split('|');
            //    if (Decimal.TryParse(flightInfo[0], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-GB"), out decimal price))
            //    {
            //        Price = price;
            //    }
            //    FlightNumber = flightInfo[2];

            //    DateTime date;
            //    if (DateTime.TryParse(flightInfo[3], out date))
            //    {
            //        DepartureTime = date;
            //    }
            //    if (DateTime.TryParse(flightInfo[4], out date))
            //    {
            //        ArrivalTime = date;
            //    }
            //}
            //catch
            //{
            //}
        }
    }
}
