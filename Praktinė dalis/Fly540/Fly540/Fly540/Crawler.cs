namespace Fly540
{
    using RestSharp;
    using Fly540.Functions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Globalization;
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
            Client.AddDefaultHeader("DNT", "1");
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

            string[] outboundAndInboundRequestId = RegexFunctions.RegexToStringArray(responseBody, Regexes.OutboundAndInboundRequestId);

            List<Combinations> combinationsList = Combinations.GetCombinations(OutboundData, InboundData);

            foreach(Combinations combination in combinationsList)
            {
                string requestKey = GetPassengerDetails(combination, outboundAndInboundRequestId);
                if (TryGetTaxes(requestKey, out string taxesResponseBody))
                {
                    string[][] pricesAndTaxes = RegexFunctions.RegexToMultiStringArray(taxesResponseBody, Regexes.PriceAndTaxes);

                    combination.Outbound.PriceWithoutTaxes = decimal.Parse(pricesAndTaxes.First().First());
                    combination.Outbound.Taxes = decimal.Parse(pricesAndTaxes.First().Last());

                    if (_Sc.IsRt)
                    {
                        combination.Inbound.PriceWithoutTaxes = decimal.Parse(pricesAndTaxes.Last().First());
                        combination.Inbound.Taxes = decimal.Parse(pricesAndTaxes.Last().Last());
                    }
                }

                combination.PriceWithoutTaxes = _Sc.IsRt ? combination.Outbound.PriceWithoutTaxes + combination.Inbound.PriceWithoutTaxes : combination.Outbound.PriceWithoutTaxes;
                combination.Taxes = _Sc.IsRt ? combination.Outbound.Taxes + combination.Inbound.Taxes : combination.Outbound.Taxes;
                combination.FullPrice = _Sc.IsRt ? combination.Outbound.FullPrice + combination.Inbound.FullPrice : combination.Outbound.FullPrice;
            }

            Datasave.TryFillTableWithData(combinationsList);
            return true;
        }
        private bool TryLoadPage(out string responseBody)
        {
            Client.BaseUrl = new Uri(ConstructUrlForFlights(), UriKind.Absolute);

            RestRequest request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);
            responseBody = response.Content;

            Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

            return responseBody != null;
        }
        private string ConstructUrlForFlights()
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
            string[][] departureAndArrivalBlocks = RegexFunctions.RegexToMultiStringArray(sector, Regexes.DepartureAndArrivalBlocks);

            string origin = RegexFunctions.RegexToString(departureAndArrivalBlocks[0][0], Regexes.Location);
            string destination = RegexFunctions.RegexToString(departureAndArrivalBlocks[0][1], Regexes.Location);
            string[] fullDate = GetDate(departureAndArrivalBlocks);
            string flightNumber = RegexFunctions.RegexToString(departureAndArrivalBlocks[0][0], Regexes.FlightNumber);
            string flightKey = RegexFunctions.RegexToString(sector, Regexes.FlightKey);

            foreach (string pricecard in pricecards)
            {
                string[][] flightInfo = RegexFunctions.RegexToMultiStringArray(pricecard, Regexes.FlightInfo);

                Flight flight = new Flight(origin, destination, fullDate, flightNumber, flightInfo, flightKey);
                if(flight.FullPrice != null)
                {
                    collectedDataList.Add(flight);
                }    
            }

            return collectedDataList;
        }
        private string[] GetDate(string[][] departureAndArrivalBlocks)
        {
            string[] fullDate = new string[2];
            string[][] departHoursDayMonth = RegexFunctions.RegexToMultiStringArray(departureAndArrivalBlocks[0][0], Regexes.FlightHoursDayMonth);
            string[][] arrivalHoursDayMonth = RegexFunctions.RegexToMultiStringArray(departureAndArrivalBlocks[0][1], Regexes.FlightHoursDayMonth);
            
            fullDate[0] = _Sc.OutboundYear + "-" + departHoursDayMonth[0][1] + "-" + departHoursDayMonth[0][0];

            fullDate[1] = (_Sc.IsRt ? _Sc.InboundYear : _Sc.OutboundYear) + "-" + arrivalHoursDayMonth[0][1] + "-" + arrivalHoursDayMonth[0][0];

            return fullDate;
        }
        private string GetPassengerDetails(Combinations combination, string[] requestId)
        {
            char cabinClassForOutbound = Dictionaries.CabinClassToInt[combination.Outbound.FareFamily];
            Flight outboundSector = combination.Outbound;
            string requestBody;
            if (_Sc.IsRt)
            {
                char cabinClassForInbound = Dictionaries.CabinClassToInt[combination.Inbound.FareFamily];
                Flight inboundSector = combination.Inbound;
                requestBody = "option=com_travel&task=airbook.addPassengers&outbound_request_id=" + requestId.First() +
                "&inbound_request_id=" + requestId.Last() +
                "&outbound_solution_id=" + outboundSector.FlightKey +
                "&outbound_cabin_class=" + cabinClassForOutbound +
                "&inbound_solution_id=" + inboundSector.FlightKey +
                "&inbound_cabin_class=" + cabinClassForInbound +
                "&adults=1&children=0&infants=0&change_flight=";
            }
            else
            {
                requestBody = "option=com_travel&task=airbook.addPassengers&outbound_request_id=" + requestId.First() +
               "&inbound_request_id=&outbound_solution_id=" + outboundSector.FlightKey +
               "&outbound_cabin_class=" + cabinClassForOutbound +
               "&inbound_solution_id=&inbound_cabin_class=&adults=1&children=0&infants=0&change_flight=";
            }

            string referer = ConstructRefererForDetails();

            Client.BaseUrl = new Uri(Urls.PassengerDetails, UriKind.Absolute);

            RestRequest request = new RestRequest("", Method.POST);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Referer", referer);
            request.AddParameter("text/xml", requestBody, ParameterType.RequestBody);

            Client.FollowRedirects = false;

            IRestResponse response = Client.Execute(request);

            Console.WriteLine(Urls.PassengerDetails + " " + response.StatusCode);

            return response.Headers[7].Value.ToString();
        }
        private string ConstructRefererForDetails()
        {
            string isOneWay = _Sc.IsRt ? "0" : "1";

            string outboundMonth = _Sc.OutboundDate.ToString("MMM", CultureInfo.InvariantCulture);
            string inboundMonth = _Sc.InboundDate.ToString("MMM", CultureInfo.InvariantCulture);

            return $"{Urls.FlightPage}?isoneway={isOneWay}&currency=KES"
                + $"&depairportcode={_Sc.Origin}&arrvairportcode={_Sc.Destination}"
                + $"&date_from={_Sc.OutboundDay}{outboundMonth}{_Sc.OutboundYear}"
                + $"&date_to={_Sc.InboundDay}{inboundMonth}{_Sc.InboundYear}"
                + "&adult_no=1&children_no=0&infant_no=0&searchFlight=&change_flight=";
        }
        private bool TryGetTaxes(string requestKey, out string responseBody)
        {
            string referer = ConstructRefererForTaxes();
            Client.BaseUrl = new Uri(Urls.StartPage + requestKey, UriKind.Absolute);
            RestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Sec-Fetch-Site", "same-origin");
            request.AddHeader("Sec-Fetch-Mode", "navigate");
            request.AddHeader("Sec-Fetch-User", "?1");
            request.AddHeader("Sec-Fetch-Dest", "document");
            request.AddHeader("Referer", referer);

            Client.FollowRedirects = false;

            IRestResponse response = Client.Execute(request);
            responseBody = response.Content;

            Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

            return responseBody != null;
        }
        private string ConstructRefererForTaxes()
        {
            string isOneWay = _Sc.IsRt ? "0" : "1";

            return $"{Urls.FlightPage}?isoneway={isOneWay}&currency=KES"
                + $"&depairportcode={_Sc.Origin}"
                + $"&arrvairportcode={_Sc.Destination}"
                + $"&date_from={_Sc.OutboundDay}{_Sc.OutboundDate.ToString("MMM", CultureInfo.InvariantCulture)}{_Sc.OutboundYear}"
                + $"&date_to={_Sc.InboundDay}{_Sc.InboundDate.ToString("MMM", CultureInfo.InvariantCulture)}{_Sc.InboundYear}"
                + "&adult_no=1&children_no=0&infant_no=0&searchFlight=&change_flight=";
        }
    }
}
