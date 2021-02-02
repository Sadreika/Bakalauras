namespace AirportCrawler
{
    public static class Regexes
    {
        public static string DataRow = @"<tr\s*class=\u0022(?:light|dark)-row\u0022>(.*?)</tr>";
        public static string AirportData = @">([a-z ]+)</a>(?:[^:]+:)\s*</span>([a-z\s*]+)(?:[^:]+:)\s*</span>([a-z\s*]+)(?:[^:]+:)\s*</span>([a-z\s*]+)(?:[^:]+:)\s*</span>([a-z\s*]+)";
        public static string UnavailablePage = @"There\s*are\s*only\s*[0-9]+\s*pages\s*to\s*view";
    }
}
