namespace AirportCrawler
{
    using AirportCrawler.Functions;
    using RestSharp;
    using System;
    using System.Text.RegularExpressions;

    public class Crawler
    {
        private RestClient Client = new RestClient();

        private DatasaveFunctions DatasaveFunctionsObject = new DatasaveFunctions(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True");
        public Crawler()
        {
            Client.AddDefaultHeader("Host", "www.world-airport-codes.com");
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0";
            Client.AddDefaultHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            Client.AddDefaultHeader("Accept-Language", "lt,en-US;q=0.8,en;q=0.6,ru;q=0.4,pl;q=0.2");
            Client.AddDefaultHeader("Connection", "keep-alive");
            Client.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
        }

        public void StartCrawler()
        {
            DatasaveFunctionsObject.TryCreateTable();

            for (char c = 'a'; c <= 'z'; c++)
            {
                int pageNumber = 1;
                do
                {
                    if(!TryLoadAirports(c, pageNumber))
                    {
                        break;
                    }
                }
                while (true);
            }
        }

        public bool TryLoadAirports(char c, int pageNumber)
        {
            Client.BaseUrl = new Uri(Urls.airportCodeUrl + $"{c}.html?page={pageNumber}", UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);
            IRestResponse response = Client.Execute(request);

            return TryExtractData(response.Content);
        }

        public bool TryExtractData(string content)
        {
            if(Regex.IsMatch(content, Regexes.UnavailablePage))
            {
                return false;
            }
            string[] rowDataArray = RegexFunctions.RegexToStringArray(content, Regexes.DataRow);
            string[][] airportInfo;
            foreach (string rowData in rowDataArray)
            {
                airportInfo = RegexFunctions.RegexToMultiStringArray(content, Regexes.AirportData);
            }
            
            return true;
        }
    }
}