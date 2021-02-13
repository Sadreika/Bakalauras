namespace AirportCrawler
{
    using AirportCrawler.Functions;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Crawler
    {
        private RestClient Client = new RestClient();

        private DatasaveFunctions Datasave = new DatasaveFunctions();
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
            Datasave.StartConnection();
            List<string> sqlColumnCodes = new List<string>()
            {
                { "Id int IDENTITY(1,1) NOT NULL PRIMARY KEY" },
                { "Airport varchar(255) NOT NULL" },
                { "Type varchar(255)" },
                { "City varchar(255)" },
                { "Country varchar(255) NOT NULL" },
                { "IATA varchar(255) NOT NULL" },
            };

            Datasave.TryRemoveTable("Airports");
            if (Datasave.TryCreateTable($"Airports", sqlColumnCodes))
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    int pageNumber = 1;
                    do
                    {
                        if (!TryLoadAirports(c, pageNumber))
                        {
                            break;
                        }
                        pageNumber += 1;
                    }
                    while (true);
                }
            }
            Datasave.EndConnection();
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
            List<string> columnNames = new List<string>()
            {
                { "Airport" },
                { "Type" },
                { "City" },
                { "Country" },
                { "IATA" },
            };
            if (Regex.IsMatch(content, Regexes.UnavailablePage))
            {
                return false;
            }

            string[] rowDataArray = RegexFunctions.RegexToStringArray(content, Regexes.DataRow);
            string[][] airportsInfo = new string[rowDataArray.Length][];
            foreach (string rowData in rowDataArray)
            {
                airportsInfo = RegexFunctions.RegexToMultiStringArray(content, Regexes.AirportData);
            }

            foreach(string[] airportInfo in airportsInfo)
            {
                Datasave.TryFillTableWithData("Airports", columnNames, airportInfo.ToList());
            }
            
            return true;
        }
    }
}