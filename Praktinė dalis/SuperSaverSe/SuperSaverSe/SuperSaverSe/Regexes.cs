namespace SuperSaverSe
{
    public class Regexes
    {
        public static string UnavailableFlight = @"Meddelande\s*från\s*Supersavertravel";

        public static string ReFlightsJson = @"airResultApplicationModel\.dataSourceManagerArgs\s*\=\s*(\{.*?\})\s*\;\s*airResultApplicationModel\.hotelOverlayManagerArgs";

        public static string ReFlightPrices = @"\u0022(\d+)\u0022:\s*{\s*\u0022.*?(?:selection|bounds).*?total.*?\u0022price\u0022:\s*(\d[\d\,\.\s]*)";

        public static string ReDigits = @"(\d+)";

        public static string ReCurrency = @"siteCurrency\u0022\:\u0022(\w{3})\u0022";

        public static string ReRemoveDay = @"\w{2}\s*(.*?)$";
    }
}
