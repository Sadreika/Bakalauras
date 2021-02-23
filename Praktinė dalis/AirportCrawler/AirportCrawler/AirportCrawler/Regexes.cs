namespace AirportCrawler
{
    public static class Regexes
    {
        public static string DataRow = @"<tr\s*class=\u0022(?:light|dark)-row\u0022>(.*?)</tr>";
        public static string AirportData = @"html\u0022>([^<]+)</a>(?:[^:]+:)\s*</span>([^<]+)(?:[^:]+:)\s*</span>([^<]+)(?:[^:]+:)\s*</span>([^<]+)<(?:[^:]+:)\s*</span>([^<]+)";
        public static string UnavailablePage = @"There\s*are\s*only\s*[0-9]+\s*pages\s*to\s*view";
    }
}
