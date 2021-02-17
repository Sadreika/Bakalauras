namespace Fly540
{
    public class Regexes
    {
        public static string UnavailableFlight = @"No\s*Flights";

        public static string SearchDepartAndReturnYears = @"\s*[a-z]{3}\s*[0-9]+,\s*[a-z]{3}\s*([0-9]+)";
        
        public static string OutboundRT = @"fly5-flights\s*fly5-depart\s*th(.*)fly5-flights\s*fly5-return\s*th";

        public static string OutboundOW = @"fly5-flights\s*fly5-depart\s*th(.*)fly5-totalprice\s*fly5-terms";
        
        public static string OutboundAndInboundRequestId = @"request_id\u0022\s*value=\u0022([0-9]+)\u0022";

        public static string Inbound = @"fly5-flights\s*fly5-return\s*th(.*)fly5-totalprice\s*fly5-terms";
        
        public static string Flight = @"<div\s*class=\u0022fly5-result\s*fly5-result(.*?</div>\s*</div>)\s*</div>\s*</div>\s*</div>\s*</div>";
       
        public static string DepartureAndArrivalBlocks = @"Departs\u0022(.*?)</td>.*?Arrives\u0022(.*?)</td>";
      
        public static string Location = @"\u0028([A-Z]{3})";
       
        public static string FlightHoursDayMonth = @"([0-9:]+am|[0-9:]+pm).*?([A-Z]{3}\s*[0-9]+,\s*[A-Z]{3})";
      
        public static string PriceCard = @"<div\s*id=\u0022flt[0-9]+-(.*?)((</div></div>)|(</div>\s*</div>))";
        
        public static string FlightInfo = @"(?:header\s*class-[0-9]+\u0022>(.*?)<).*(?:(?:class=\u0022pkgprice\u0022>([a-z]{3})\s*([0-9,]+).*(?:(?:Only\s*([0-9]+)\s*seat)|(?:</button>)))|(SOLD\s*OUT))";
       
        public static string FlightNumber = @"<span\s*id=.*?([0-9]+)";

        public static string FlightKey = @"data-flight-key=\u0022(.*?)\u0022";
     
        public static string TotalPriceBlock = @"<div\s*id=\u0022breakdown\u0022(.*?)</div></div></div>";
       
        public static string PriceAndTaxes = @">[A-Z]{3}\s*-\s*[A-Z]{3}.*?num\u0022>([0-9,.]+).*?num\u0022>([0-9,.]+)";
    }
}
