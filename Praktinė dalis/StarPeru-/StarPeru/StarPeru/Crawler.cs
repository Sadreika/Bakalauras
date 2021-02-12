namespace StarPeru
{
    using RestSharp;
    using StarPeru.Functions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Crawler
    {
        private RestClient Client = new RestClient();
        private SearchCriteria _Sc;

        private List<Flight> OutboundData = new List<Flight>();
        private List<Flight> InboundData = new List<Flight>();

        private DatasaveFunctions Datasave = new DatasaveFunctions();
        public Crawler()
        {
            Client.AddDefaultHeader("Host", "www.starperu.com");
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0";
            Client.AddDefaultHeader("Accept-Language", "en-GB,en;q=0.5");
            Client.AddDefaultHeader("Origin", Urls.StartPage);
            Client.AddDefaultHeader("Connection", "keep-alive");
            Client.AddDefaultHeader("Referer", $"{Urls.StartPage}es");
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

            List<Combinations> combinationsList = Combinations.GetCombinations(OutboundData, InboundData);

            foreach(Combinations combination in combinationsList)
            {
                if(_Sc.IsRt)
                {
                    TryGetTaxes(out string responseBodyTaxes, combination.Outbound.FlightCode, combination.Inbound.FlightCode);
                    string[] priceInfo = RegexFunctions.RegexToMultiStringArray(responseBodyTaxes, Regexes.Taxes).First();

                    if (Decimal.TryParse(priceInfo[0], out decimal priceWithoutTaxes))
                    {
                        combination.PriceWithoutTaxes = priceWithoutTaxes;
                    }
                    if (Decimal.TryParse(priceInfo[1], out decimal taxes))
                    {
                        combination.Taxes = taxes;
                    }
                    if (Decimal.TryParse(priceInfo[2], out decimal fullPrice))
                    {
                        combination.FullPrice = fullPrice;
                    }
                }
                else
                {
                    TryGetTaxes(out string responseBodyTaxes, combination.Outbound.FlightCode);
                }
            }

            Datasave.TryToSaveFlights(combinationsList);
            return true;
        }

        private bool TryLoadPage(out string responseBody)
        {
            Client.BaseUrl = new Uri(Urls.FlightPage, UriKind.Absolute);

            RestRequest request = new RestRequest("", Method.POST);
            string postBody = ConstructPostBodyForFlight();

            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Upgrade-Insecure-Requests", "1");

            request.AddParameter("text/xml", postBody, ParameterType.RequestBody);

            IRestResponse response = Client.Execute(request);
            responseBody = response.Content;

            return responseBody != null;
        }
        private string ConstructPostBodyForFlight()
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

            string[][] sectorOriginAndDestination = RegexFunctions.RegexToMultiStringArray(sector, Regexes.SectorOriginAndDestination);
            string[][] sectorsInfo = RegexFunctions.RegexToMultiStringArray(sector, Regexes.SectorInfo);
            string flightCode = RegexFunctions.RegexToString(sector, Regexes.FlightCode);

            foreach (string[] sectorInfo in sectorsInfo)
            {
                Flight flight = new Flight(sectorOriginAndDestination, sectorInfo, flightCode);
                collectedDataList.Add(flight);
            }

            return collectedDataList;
        }
        private bool TryGetTaxes(out string responseBodyTaxes, string outBoundFlightCode, string inBoundFlightCode = null)
        {
            Client.BaseUrl = new Uri(Urls.FlightPage, UriKind.Absolute);

            RestRequest request = new RestRequest("ObtenerTarifas", Method.POST);

            if(_Sc.IsRt)
            {
                request.AddParameter("text/xml", ConstructPostBodyForTaxes(outBoundFlightCode, inBoundFlightCode), ParameterType.RequestBody);
            }
            else
            {
                request.AddParameter("text/xml", ConstructPostBodyForTaxes(outBoundFlightCode), ParameterType.RequestBody);
            }
            
            request.AddHeader("Accept", "*/*");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Referer", Urls.FlightPage);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            
            IRestResponse response = Client.Execute(request);
            responseBodyTaxes = response.Content;

            return responseBodyTaxes != null;
        }
        private string ConstructPostBodyForTaxes(string outBoundFlightCode, string inBoundFlightCode = null)
        {
            if(_Sc.IsRt)
            {
                return $"cod_origen={_Sc.Origin}&cod_destino={_Sc.Destination}&cant_adl=1&cant_chd=0&cant_inf=0&codigo_desc=&fecha_ida={_Sc.OutboundDate.ToString("yyyy-MM-dd")}&fecha_retorno={_Sc.InboundDate.ToString("yyyy-MM-dd")}&tipo_viaje=R&grupo_retorno={inBoundFlightCode}&grupo_ida={outBoundFlightCode}";
            }
            else
            {
                return $"cod_origen={_Sc.Origin}&cod_destino={_Sc.Destination}&cant_adl=1&cant_chd=0&cant_inf=0&codigo_desc=&fecha_ida={_Sc.OutboundDate.ToString("yyyy-MM-dd")}&fecha_retorno={_Sc.OutboundDate.ToString("yyyy-MM-dd")}&tipo_viaje=O&grupo_ida={inBoundFlightCode}";
            }     
        }
    }
}
