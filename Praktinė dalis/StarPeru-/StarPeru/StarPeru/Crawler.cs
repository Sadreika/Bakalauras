namespace StarPeru
{
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using global::Functions.StarPeru;

    public class Crawler
    {
        private RestClient Client = new RestClient();
        private SearchCriteria _Sc;

        private List<Flight> OutboundData = new List<Flight>();
        private List<Flight> InboundData = new List<Flight>();

        //private List<Combinations> CombinationsList = new List<Combinations>();

        public Crawler()
        {
            Client.AddDefaultHeader("Host", "www.starperu.com");
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0";
            Client.AddDefaultHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            Client.AddDefaultHeader("Accept-Language", "lt,en-US;q=0.8,en;q=0.6,ru;q=0.4,pl;q=0.2");
            Client.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded");
            Client.AddDefaultHeader("Origin", Urls.StartPage);
            Client.AddDefaultHeader("DNT", "1");
            Client.AddDefaultHeader("Connection", "keep-alive");
            Client.AddDefaultHeader("Referer", $"{Urls.StartPage}es");
            Client.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
        }

        public bool Start(string searchCriteria)
        {
            _Sc = new SearchCriteria(searchCriteria);

            if(!TryLoadPage(out string responseBody))
            {
                return false;
            }

            if(!TryExtractBounds(responseBody, out string[] bounds))
            {
                return false;
            }

            string[] outboundSectors = RegexFunctions.RegexToStringArray(bounds[0], Regexes.Sectors);

            foreach (string outboundSector in outboundSectors)
            {
                OutboundData.AddRange(ExtractData(outboundSector));
            }

            if (_Sc.IsRt)
            {
                string[] inboundSectors = RegexFunctions.RegexToStringArray(bounds[1], Regexes.Sectors);

                foreach (string inboundSector in inboundSectors)
                {
                    InboundData.AddRange(ExtractData(inboundSector));
                }
            }

            //foreach (Flight outbound in OutboundData)
            //{
            //    if (_afo.IsRt)
            //    {
            //        foreach (Flight inbound in InboundData)
            //        {
            //            Combinations combinations = new Combinations(outbound, inbound);
            //            CombinationsList.Add(combinations);
            //        }
            //    }
            //    else
            //    {
            //        Combinations combinations = new Combinations(outbound);
            //        CombinationsList.Add(combinations);
            //    }
            //}

            //return CombinationsList;
            return true;
        }

        private bool TryLoadPage(out string responseBody)
        {
            Client.BaseUrl = new Uri(Urls.StartPage, UriKind.Absolute);

            RestRequest request = new RestRequest("Booking1", Method.POST);
            string postBody = ConstructPostBody();

            request.AddParameter("text/xml", postBody, ParameterType.RequestBody);

            IRestResponse response = Client.Execute(request);
            responseBody = response.Content;

            return responseBody != null;
        }
        private string ConstructPostBody()
        {
            string isRt = _Sc.IsRt ? "R" : "O";
            string postBody = $"tipo_viaje={isRt}&origen={_Sc.Origin}&destino={_Sc.Destination}" +
                $"&date_from={_Sc.OutboundDay}%2F{_Sc.OutboundMonth}%2F{_Sc.OutboundYear}";

            postBody += _Sc.IsRt
                ? $"&date_to={_Sc.InboundDay}%2F{_Sc.InboundMonth}%2F{_Sc.InboundYear}"
                : $"&date_to={_Sc.OutboundDay}%2F{_Sc.OutboundMonth}%2F{_Sc.OutboundYear}";
        
            postBody += "&cant_adultos=1&cant_ninos=0&cant_infantes=0&codigo_desc=";

            return postBody;
        }
        private bool TryExtractBounds(string responseBody, out string[] bounds)
        {
            bounds = RegexFunctions.RegexToStringArray(responseBody, Regexes.Bounds);

            return bounds.Length != 0;
        }
        private List<Flight> ExtractData(string sector)
        {
            List<Flight> collectedDataList = new List<Flight>();

            string[] sectorOriginAndDestination = RegexFunctions.RegexToStringArray(sector, Regexes.SectorOriginAndDestination);
            string[] sectorsInfo = RegexFunctions.RegexToStringArray(sector, Regexes.SectorInfo);

            foreach (string sectorInfo in sectorsInfo)
            {
                Flight flight = new Flight(sectorOriginAndDestination, sectorInfo);
                collectedDataList.Add(flight);
            }

            return collectedDataList;
        }
    }
}
