namespace AirportCrawler
{
    using RestSharp;
    using System;
    using System.IO;

    public class Crawler
    {
        private RestClient Client = new RestClient();
        private string Path = @"C:\Users\mariu\Desktop\Games\" + DateTime.Today.ToString("yyyyMMdd") + ".txt"; // REIKIA SUTVARKYTI
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
            StreamWriter streamWriter = new StreamWriter(Path);
           
            for(char c = 'a'; c <= 'z'; c++)
            {
                int pageNumber = 0;
                do
                {
                    if(!TryLoadAirports(c, pageNumber))
                    {
                        break;
                    }
                }
                while (true);
            }
          


            streamWriter.Close();
        }

        public bool TryLoadAirports(char c, int pageNumber)
        {
            Client.BaseUrl = new Uri(Urls.airportCodeUrl + $"{c}.html?page={pageNumber}", UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);
            IRestResponse response = Client.Execute(request);
            TryExtractData(response.Content);


            return false;
        }

        public bool TryExtractData(string content /*, StreamWriter streamWriter*/)
        {

            //string[][] allGames = Regexes.RegexToMultiStringArray(content, Regexes.TitleAndPrice);

            //foreach (string[] game in allGames)
            //{
            //    streamWriter.WriteLine("Title: " + game[0] + " Price: " + game[1]);
            //}

            //if (allGames.Length != 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
    }
}