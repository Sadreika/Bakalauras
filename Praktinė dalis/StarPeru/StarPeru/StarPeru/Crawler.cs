using RestSharp;
using System;
using System.Collections.Generic;

namespace StarPeru
{
    public class Crawler
    {
        private RestClient client = new RestClient();
        private Afo _afo;
        private List<Combinations> combinationsList = new List<Combinations>();
        private List<Flight> outboundData = new List<Flight>();
        private List<Flight> inboundData = new List<Flight>();

        public Crawler()
        {
            client.AddDefaultHeader("Host", "www.starperu.com");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0";
            client.AddDefaultHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.AddDefaultHeader("Accept-Language", "lt,en-US;q=0.8,en;q=0.6,ru;q=0.4,pl;q=0.2");
            client.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded");
            client.AddDefaultHeader("Origin", "https://www.starperu.com");
            client.AddDefaultHeader("DNT", "1");
            client.AddDefaultHeader("Connection", "keep-alive");
            client.AddDefaultHeader("Referer", "https://www.starperu.com/es");
            client.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
        }

        private void ExtractSearchCriterias(string searchCriteria)
        {
            string[] searchCriteriaArray = searchCriteria.Split('|');
            _afo = new Afo(searchCriteriaArray);
        }

        public List<Combinations> Start(string searchCriteria)
        {
            List<Flight> tempList = new List<Flight>();
            ExtractSearchCriterias(searchCriteria);
            string content = TryLoadPage();

            string[] bounds = Regexes.RegexToStringArray(content, Regexes.Bounds);

            string[] outboundSectors = Regexes.RegexToStringArray(bounds[0], Regexes.Sectors);
            foreach (string outboundSector in outboundSectors)
            {
                tempList = ExtractData(outboundSector);
                outboundData.AddRange(tempList);
            }

            if (_afo.IsRt)
            {
                string[] inboundSectors = Regexes.RegexToStringArray(bounds[1], Regexes.Sectors);

                foreach (string inboundSector in inboundSectors)
                {
                    tempList = ExtractData(inboundSector);
                    inboundData.AddRange(tempList);
                }
            }

   
            foreach (Flight outbound in outboundData)
            {
                if (_afo.IsRt)
                {
                    foreach (Flight inbound in inboundData)
                    {
                        Combinations combinations = new Combinations(outbound, inbound);
                        combinationsList.Add(combinations);
                    }
                }
                else
                {
                    Combinations combinations = new Combinations(outbound);
                    combinationsList.Add(combinations);
                }
            }

            return combinationsList;
        }

        private string TryLoadPage()
        {
            client.BaseUrl = new Uri(Urls.StartPage, UriKind.Absolute);
            RestRequest request = new RestRequest("Booking1", Method.POST);
            string postBody = FormPostBody();
            request.AddParameter("text/xml", postBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        private string FormPostBody()
        {
            string isRt = _afo.IsRt ? "R" : "O";
            if(_afo.IsRt)
            {
                return "tipo_viaje=" + isRt + "&origen=" + _afo.Origin + "&destino=" + _afo.Departure +
                "&date_from=" + _afo.OutboundDate.ToString("dd") + "%2F" + _afo.OutboundDate.ToString("MM") + "%2F" + _afo.OutboundYear +
                "&date_to=" + _afo.InboundDate.ToString("dd") + "%2F" + _afo.InboundDate.ToString("MM") + "%2F" + _afo.InboundYear + "&cant_adultos=1&cant_ninos=0&cant_infantes=0&codigo_desc=";
            }
            else
            {
                return "tipo_viaje=" + isRt + "&origen=" + _afo.Origin + "&destino=" + _afo.Departure +
                "&date_from=" + _afo.OutboundDate.ToString("dd") + "%2F" + _afo.OutboundDate.ToString("MM") + "%2F" + _afo.OutboundYear +
                "&date_to=" + _afo.OutboundDate.ToString("dd") + "%2F" + _afo.OutboundDate.ToString("MM") + "%2F" + _afo.OutboundYear + "&cant_adultos=1&cant_ninos=0&cant_infantes=0&codigo_desc=";
            }
            
        }

        private List<Flight> ExtractData(string sector)
        {
            List<Flight> collectedDataList = new List<Flight>();

            string[] sectorOriginAndDestination = Regexes.RegexToStringArray(sector, Regexes.SectorOriginAndDestination);
            string[] sectorsInfo = Regexes.RegexToStringArray(sector, Regexes.SectorInfo);
            foreach (string sectorInfo in sectorsInfo)
            {
                Flight flight = new Flight(sectorOriginAndDestination, sectorInfo);
                collectedDataList.Add(flight);
            }

            return collectedDataList;
        }
    }
}
