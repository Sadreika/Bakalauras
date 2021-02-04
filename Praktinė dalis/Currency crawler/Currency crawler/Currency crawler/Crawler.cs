namespace Currency_crawler
{
    using Currency_crawler.Functions;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Crawler
    {
        private RestClient Client = new RestClient();

        public Crawler()
        {
            Client.AddDefaultHeader("Host", "www1.oanda.com");
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0";
            Client.AddDefaultHeader("Accept-Language", "en-GB,en;q=0.5");
            Client.AddDefaultHeader("DNT", "1");
            Client.AddDefaultHeader("Connection", "keep-alive");
        }

        public void StartCrawler()
        {
            TryLoadBasePage(out string javaScriptCacheCode);
            TryLoadCurrencyList(javaScriptCacheCode, out List<string> currencies);
            
        }

        public bool TryLoadBasePage(out string javaScriptCacheCode)
        {
            Client.BaseUrl = new Uri(Urls.BasePageUrl, UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            
            IRestResponse response = Client.Execute(request);
            javaScriptCacheCode = RegexFunctions.RegexToString(response.Content, Regexes.JavaScriptCacheCode);

            return javaScriptCacheCode != null;
        }

        public bool TryLoadCurrencyList(string javaScriptCacheCode, out List<string> currencies)
        {
            currencies = new List<string>();
            Client.BaseUrl = new Uri(Urls.BasePageUrl + $"cache{javaScriptCacheCode}.js", UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Referer", "https://www1.oanda.com/currency/converter/");
            IRestResponse response = Client.Execute(request);
            string currencyJson = RegexFunctions.RegexToString(response.Content, Regexes.CurrencyJson);


            return false;
        }
    }
}