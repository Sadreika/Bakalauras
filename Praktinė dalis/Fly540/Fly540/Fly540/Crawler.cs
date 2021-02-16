namespace Fly540
{
    using RestSharp;
    using Fly540.Functions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Crawler
    {
        private RestClient Client = new RestClient();
        private SearchCriteria _Sc;

        private List<Flight> OutboundData = new List<Flight>();
        private List<Flight> InboundData = new List<Flight>();

        private DatasaveFunctions Datasave = new DatasaveFunctions();
        public Crawler()
        {
            Client.AddDefaultHeader("Host", "www.fly540.com");
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0";
            Client.AddDefaultHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            Client.AddDefaultHeader("Accept-Language", "en-GB,en;q=0.5");
            Client.AddDefaultHeader("Connection", "keep-alive");
            Client.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
        }
        public bool Start(string searchCriteria)
        {
            _Sc = new SearchCriteria(searchCriteria);

            if(!TryLoadPage(out string responseBody))
            {
                return false;
            }

            if (Regex.IsMatch(responseBody, Regexes.UnavailableFlight))
            {
                return false;
            }

            if (!TryExtractBounds(responseBody, out string[] bounds))
            {
                return false;
            }

            string[] outboundSectors = RegexFunctions.RegexToStringArray(bounds[0], Regexes.Flight);

            foreach (string outboundSector in outboundSectors)
            {
                OutboundData.AddRange(ExtractData(outboundSector));
            }

            if (_Sc.IsRt)
            {
                string[] inboundSectors = RegexFunctions.RegexToStringArray(bounds[1], Regexes.Flight);

                foreach (string inboundSector in inboundSectors)
                {
                    InboundData.AddRange(ExtractData(inboundSector));
                }
            }

            //List<Combinations> combinationsList = Combinations.GetCombinations(OutboundData, InboundData);

            //foreach(Combinations combination in combinationsList)
            //{
            //    string responseBodyTaxes;
            //    if (_Sc.IsRt)
            //    {
            //        TryGetTaxes(out responseBodyTaxes, combination.Outbound.FlightCode, combination.Inbound.FlightCode);
            //    }
            //    else
            //    {
            //        TryGetTaxes(out responseBodyTaxes, combination.Outbound.FlightCode);
            //    }

            //    string[] priceInfo = RegexFunctions.RegexToMultiStringArray(responseBodyTaxes, Regexes.Taxes).First();

            //    if (Decimal.TryParse(priceInfo[0], out decimal priceWithoutTaxes))
            //    {
            //        combination.PriceWithoutTaxes = priceWithoutTaxes;
            //    }
            //    if (Decimal.TryParse(priceInfo[1], out decimal taxes))
            //    {
            //        combination.Taxes = taxes;
            //    }
            //    if (Decimal.TryParse(priceInfo[2], out decimal fullPrice))
            //    {
            //        combination.FullPrice = fullPrice;
            //    }
            //}

            //Datasave.TryFillTableWithData(combinationsList);
            return true;
        }

        private bool TryLoadPage(out string responseBody)
        {
            Client.BaseUrl = new Uri(ConstructUrl(), UriKind.Absolute);

            RestRequest request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);
            responseBody = response.Content;

            Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

            return responseBody != null;
        }
        private string ConstructUrl()
        {
            string isRt = _Sc.IsRt ? "0" : "1";

            return Urls.FlightPage + $"?isoneway={isRt}&currency=KES&depairportcode={_Sc.Origin}&arrvairportcode={_Sc.Destination}" +
                $"&date_from={_Sc.OutboundDate.ToString("dd+MMM+yyyy")}&date_to={_Sc.InboundDate.ToString("dd+MMM+yyyy")}" +
                $"&adult_no=1&children_no=0&infant_no=0&searchFlight=&change_flight=";
        }
        private bool TryExtractBounds(string responseBody, out string[] bounds)
        {
            if(_Sc.IsRt)
            {
                bounds = new string[2];
                bounds[0] = RegexFunctions.RegexToString(responseBody, Regexes.OutboundRT);
                bounds[1] = RegexFunctions.RegexToString(responseBody, Regexes.Inbound);
            }
            else
            {
                bounds = new string[1];
                bounds[0] = RegexFunctions.RegexToString(responseBody, Regexes.OutboundOW);
            }

            return bounds.Length != 0;
        }
        private List<Flight> ExtractData(string sector)
        {
            List<Flight> collectedDataList = new List<Flight>();

            string[] pricecards = RegexFunctions.RegexToStringArray(sector, Regexes.PriceCard);
            string flightKey = RegexFunctions.RegexToString(sector, Regexes.FlightKey);

            foreach (string pricecard in pricecards)
            {
                string[][] flightInfo = RegexFunctions.RegexToMultiStringArray(pricecard, Regexes.FareFamilyCurrencyPriceSeatsSoldOut);

                Flight flight = new Flight(flightInfo, flightKey);


                //string[][] departureAndArrivalBlocks = _isf.Regex.RegexMatchesToMultiArray(sectorInfo, Regexes.DepartureAndArrivalBlocks);

                //leg.Origin = _isf.Regex.RegexMatchesToString(departureAndArrivalBlocks[0][0], Regexes.Location);
                //leg.Destination = _isf.Regex.RegexMatchesToString(departureAndArrivalBlocks[0][1], Regexes.Location);

                //string[] fullDate = GetDate(departureAndArrivalBlocks);

                //leg.DepartureDateTimeString = fullDate[0];
                //leg.ArrivalDateTimeString = fullDate[1];

                //leg.FlightNumber = leg.CarrierCode + _isf.Regex.RegexMatchesToString(departureAndArrivalBlocks[0][0], Regexes.FlightNumber);



                collectedDataList.Add(flight);
            }

            //string[][] sectorOriginAndDestination = RegexFunctions.RegexToMultiStringArray(sector, Regexes.)
            //string[][] sectorOriginAndDestination = RegexFunctions.RegexToMultiStringArray(sector, Regexes.SectorOriginAndDestination);
            //string[][] sectorsInfo = RegexFunctions.RegexToMultiStringArray(sector, Regexes.SectorInfo);
            //string[] flightCode = RegexFunctions.RegexToStringArray(sector, Regexes.FlightCode);

            //int flightCount = 0;
            //foreach (string[] sectorInfo in sectorsInfo)
            //{
            //    Flight flight = new Flight(sectorOriginAndDestination, sectorInfo, flightCode[flightCount]);
            //    collectedDataList.Add(flight);

            //    flightCount++;
            //}

            return collectedDataList;
        }

        //private bool TryGetTaxes(out string responseBodyTaxes, string outBoundFlightCode, string inBoundFlightCode = null)
        //{
        //    Client.BaseUrl = new Uri(Urls.FlightPage, UriKind.Absolute);

        //    RestRequest request = new RestRequest("ObtenerTarifas", Method.POST);

        //    if(_Sc.IsRt)
        //    {
        //        request.AddParameter("text/xml", ConstructPostBodyForTaxes(outBoundFlightCode, inBoundFlightCode), ParameterType.RequestBody);
        //    }
        //    else
        //    {
        //        request.AddParameter("text/xml", ConstructPostBodyForTaxes(outBoundFlightCode), ParameterType.RequestBody);
        //    }

        //    request.AddHeader("Accept", "*/*");
        //    request.AddHeader("X-Requested-With", "XMLHttpRequest");
        //    request.AddHeader("Referer", Urls.FlightPage);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

        //    IRestResponse response = Client.Execute(request);
        //    responseBodyTaxes = response.Content;

        //    Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

        //    return responseBodyTaxes != null;
        //}
        //private string ConstructPostBodyForTaxes(string outBoundFlightCode, string inBoundFlightCode = null)
        //{
        //    if(_Sc.IsRt)
        //    {
        //        return $"cod_origen={_Sc.Origin}&cod_destino={_Sc.Destination}&cant_adl=1&cant_chd=0&cant_inf=0&codigo_desc=&fecha_ida={_Sc.OutboundDate.ToString("yyyy-MM-dd")}&fecha_retorno={_Sc.InboundDate.ToString("yyyy-MM-dd")}&tipo_viaje=R&grupo_retorno={inBoundFlightCode}&grupo_ida={outBoundFlightCode}";
        //    }
        //    else
        //    {
        //        return $"cod_origen={_Sc.Origin}&cod_destino={_Sc.Destination}&cant_adl=1&cant_chd=0&cant_inf=0&codigo_desc=&fecha_ida={_Sc.OutboundDate.ToString("yyyy-MM-dd")}&fecha_retorno={_Sc.OutboundDate.ToString("yyyy-MM-dd")}&tipo_viaje=O&grupo_retorno=&grupo_ida={outBoundFlightCode}";
        //    }     
        //}
    }
}
