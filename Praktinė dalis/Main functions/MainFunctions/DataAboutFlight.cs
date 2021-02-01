namespace Flights_Recommendation_System_GUI.Main_functions
{
    using System;
    public class DataAboutFlight
    {
        public string Origin { get; }
        public string Departure { get; }
        public string OutboundYear { get; }
        public string OutboundMonth { get; }
        public string OutboundDay { get; }
        public DateTime OutboundDate { get; }
        public string InboundYear { get; }
        public string InboundMonth { get; }
        public string InboundDay { get; }
        public DateTime InboundDate { get; }
        public char CabinClass { get; }
        public bool IsRt { get; }
    }
}
