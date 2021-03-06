namespace SuperSaverSe
{
    using System;
    using System.Globalization;

    public class Flight
    {
        public string Origin;
        public string Destination;
        public string Connection;
        public string FlightNumber;
        public char Class;
        public string TravelDuration;
        public string Airline;

        public DateTime DepartureTime;
        public DateTime ArrivalTime;

        public Flight(string origin, string connection, string destination, string departureDateTimeString, string arrivalDateTimeString, string flightNumber, string airline, char cabinClass)
        {
            Origin = origin;
            Destination = destination;
            Connection = connection;
            Airline = airline;
            Class = cabinClass;

            FlightNumber = flightNumber;

            if (DateTime.TryParseExact(ConstructDateTimeString(departureDateTimeString), "d MMMM, yyyy HH:mm", CultureInfo.GetCultureInfo("sv-SE"), DateTimeStyles.None, out DateTime departureTime))
            {
                DepartureTime = departureTime;
            }

            if (DateTime.TryParseExact(ConstructDateTimeString(arrivalDateTimeString), "d MMMM, yyyy HH:mm", CultureInfo.GetCultureInfo("sv-SE"), DateTimeStyles.None, out DateTime arrivalTime))
            {
                ArrivalTime = arrivalTime;
            }

            TravelDuration = ArrivalTime.Subtract(DepartureTime).ToString();
        }

        private string ConstructDateTimeString(string dateTimeString)
        {
            string newDateTimeString = string.Empty;

            string[] dateTimeStringParts = dateTimeString.Split();
            for(int i = 1; i < dateTimeStringParts.Length; i++)
            {
                newDateTimeString += dateTimeStringParts[i] + " ";
            }

            newDateTimeString = newDateTimeString.Trim();
            return newDateTimeString;
        }
    }
}