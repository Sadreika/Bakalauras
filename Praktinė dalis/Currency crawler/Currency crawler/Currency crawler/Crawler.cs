namespace Currency_crawler
{
    using Currency_crawler.Functions;
    using MainDataExtractionFunctions;
    using Newtonsoft.Json.Linq;
    using RestSharp;
    using System;
    using System.Collections.Generic;

    public class Crawler
    {
        private RestClient Client = new RestClient();

        private DatasaveFunctions Datasave = new DatasaveFunctions(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True");

        public Crawler()
        {
            Client.AddDefaultHeader("Host", "www1.oanda.com");
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0";
            Client.AddDefaultHeader("Accept-Language", "en-GB,en;q=0.5");
            Client.AddDefaultHeader("DNT", "1");
            Client.AddDefaultHeader("Connection", "keep-alive");
        }

        public void StartCurrencyCrawler()
        {
            List<string> sqlColumnCodes = new List<string>()
            {
                { "Id int IDENTITY(1,1) NOT NULL PRIMARY KEY" },
                { "Search varchar(510) NOT NULL" },
                { "Value varchar(255) NOT NULL" },
                { "Display varchar(255) NOT NULL" },
            };

            Datasave.StartConnection();
            Datasave.TryRemoveTable("Currencies");
            if (Datasave.TryCreateTable($"Currencies", sqlColumnCodes))
            {
                TryLoadBasePage(out string javaScriptCacheCode);
                TryLoadCurrencyList(javaScriptCacheCode);
            }

            Console.WriteLine("Finished currency crawler");
        }

        public void StartConversionCrawler(string convertToCurrencyCode, string convertFromCurrencyCode, out double tradeRate, out double[][] chartData)
        {
            Client.BaseUrl = new Uri(Urls.BasePageUrl + $"update?base_currency_0={convertToCurrencyCode}&quote_currency={convertFromCurrencyCode}&end_date={DateTime.Now.ToString("yyyy-MM-dd")}&view=details&id=1&action=C&", UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);
            request.AddHeader("Accept", "text/javascript, text/html, application/xml, text/xml, */*");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Referer", Urls.BasePageUrl);

            IRestResponse response = Client.Execute(request);
            JToken conversionJson = JToken.Parse(response.Content);

            tradeRate = double.Parse((string)conversionJson.SelectToken("data.rate_data.bidRates[0]"));

            chartData = new double[((JArray)conversionJson.SelectToken("data.chart_data")).Count][];

            int arrayElement = 0;
            foreach (JToken chartPoint in conversionJson.SelectToken("data.chart_data"))
            {
                chartData[arrayElement] = new double[4];

                chartData[arrayElement][0] = (double)chartPoint.SelectToken("[0]");
                chartData[arrayElement][1] = (double)chartPoint.SelectToken("[1]") + 1;
                chartData[arrayElement][2] = (double)chartPoint.SelectToken("[2]");
                chartData[arrayElement][3] = (double)chartPoint.SelectToken("[3]");

                arrayElement += 1;
            }

            Console.WriteLine("Finished convertion crawler");
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

        public bool TryLoadCurrencyList(string javaScriptCacheCode)
        {
            List<string> columnNames = new List<string>()
            {
                { "Search" },
                { "Value" },
                { "Display" },
            };

            List<CurrencyInfo> currencies = new List<CurrencyInfo>();
            Client.BaseUrl = new Uri(Urls.BasePageUrl + $"cache{javaScriptCacheCode}.js", UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Referer", "Urls.BasePageUrl");
            IRestResponse response = Client.Execute(request);
            string currencyJson = RegexFunctions.RegexToString(response.Content, Regexes.CurrencyJson);
            if(currencyJson != null)
            {
                JToken currencyJsonJToken = JToken.Parse(currencyJson);
                foreach(JToken currencyData in currencyJsonJToken.SelectToken("currency_list"))
                {
                    if((string)currencyData.SelectToken("value") != null)
                    {
                        CurrencyInfo currencyInfo = new CurrencyInfo
                            ((string)currencyData.SelectToken("search"),
                            (string)currencyData.SelectToken("value"),
                            (string)currencyData.SelectToken("display"));

                        currencies.Add(currencyInfo);
                    }
                }

                Datasave.TryFillTableWithData("Currencies", columnNames, currencies);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}