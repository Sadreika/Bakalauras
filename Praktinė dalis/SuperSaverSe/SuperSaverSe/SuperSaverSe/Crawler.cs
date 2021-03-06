namespace SuperSaverSe
{
    using Newtonsoft.Json.Linq;
    using RestSharp;
    using SuperSaverSe.Functions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Crawler
    {
        private RestClient Client = new RestClient();
        private SearchCriteria _Sc;

        private DatasaveFunctions Datasave = new DatasaveFunctions();
        public Crawler()
        {
            Client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0";
            Client.AddDefaultHeader("Accept-Language", "en-US;q=0.8,en;q=0.6,ru;q=0.4");
            Client.AddDefaultHeader("DNT", "1");
            Client.AddDefaultHeader("Connection", "keep-alive");
        }
        public bool Start(string searchCriteria)
        {
            _Sc = new SearchCriteria(searchCriteria);

            if (!TryLoadFlights(out string responseBody))
            {
                return false;
            }

            if (Regex.IsMatch(responseBody, Regexes.UnavailableFlight))
            {
                return false;
            }

            JToken flightPageJson = JToken.Parse(RegexFunctions.RegexToString(responseBody, Regexes.ReFlightsJson));

            var recommendations = ExtractRecommendations(flightPageJson);

            List<Combinations> combinationsList = new List<Combinations>();

            foreach (var recommendation in recommendations)
            {
                string currency = (string)recommendation.First().SelectToken("currencyCode");

                decimal? price = null;

                if (decimal.TryParse((string)recommendation.First().SelectToken("price.total.price"), out decimal tempPrice))
                {
                    price = tempPrice;
                }

                decimal? taxes = null;

                if (decimal.TryParse((string)recommendation.First().SelectToken("price.taxesAndFees.price"), out decimal tempTax))
                {
                    taxes = tempTax;
                }

                if (!TryExtractBound(recommendation, out JToken outbound))
                {
                    continue;
                }

                if (!ExtractData(outbound, out Flight extractedOutboundFlight))
                {
                    continue;
                }

                Combinations combination;

                if (_Sc.IsRt)
                {
                    if (!TryExtractBound(recommendation, out JToken inbound, false))
                    {
                        continue;
                    }

                    if (!ExtractData(inbound, out Flight extractedInboundFlight))
                    {
                        continue;
                    }

                    combination = new Combinations(extractedOutboundFlight, extractedInboundFlight);
                }
                else
                {
                    combination = new Combinations(extractedOutboundFlight);
                }

                combination.Currency = currency;
                combination.FullPrice = price;
                combination.Taxes = taxes;
                combination.PriceWithoutTaxes = price - taxes;

                combinationsList.Add(combination);
            }

            Datasave.TryFillTableWithData(combinationsList);
            return true;
        }
        private bool TryLoadFlights(out string responseBody)
        {
            responseBody = null;

            if (!TryGetLocationsCodes(out string originCode, out string destinationCode))
            {
                return false;
            }

            if (!TryLoadPreFlights(originCode, destinationCode, out responseBody))
            {
                return false;
            }

            return responseBody != null;
        }
        private bool TryGetLocationsCodes(out string originCode, out string departureCode)
        {
            originCode = null;
            departureCode = null;

            Client.BaseUrl = new Uri(Urls.UrlOrigPortCodeSe + _Sc.Origin, UriKind.Absolute);

            RestRequest request = new RestRequest("", Method.GET);

            request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Referer", Urls.UrlBaseSe);

            IRestResponse response = Client.Execute(request);

            Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

            if (JToken.Parse(response.Content).SelectToken("model[0]") != null)
            {
                originCode = JToken.Parse(response.Content).SelectToken("model[0].id").ToString();
            }
            else
            {
                return false;
            }

            Client.BaseUrl = new Uri(Urls.UrlDestPortCodeSe + _Sc.Destination);
            response = Client.Execute(request);

            if (JToken.Parse(response.Content).SelectToken("model[0]") != null)
            {
                departureCode = JToken.Parse(response.Content).SelectToken("model[0].id").ToString();
            }

            Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

            return response.Content != null;
        }
        private bool TryLoadPreFlights(string originCode, string destinationCode, out string sourceFlights)
        {
            Client.BaseUrl = new Uri(Urls.UrlPostPreFlightsSe, UriKind.Absolute);
            string requestBody = ConstructPreFlightPostBody(originCode, destinationCode);

            RestRequest request = new RestRequest("", Method.POST);

            request.AddHeader("Origin", Urls.UrlBaseSe);
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Referer", Urls.UrlBaseSe + "/transition.action");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddParameter("text/xml", requestBody, ParameterType.RequestBody);

            IRestResponse response = Client.Execute(request);

            Console.WriteLine(Client.BaseUrl + " " + response.StatusCode);

            sourceFlights = response.Content;

            return response.Content != null;
        }
        private string ConstructPreFlightPostBody(string originCode, string destinationCode)
        {
            char pageCabin = Dictionaries.PageCabinsSe[_Sc.CabinClass];

            return $"TransitionUrl=%2Fsoker-basta-flygresor&adults=1&children=0&depDate={_Sc.OutboundDate:yyyy-MM-dd}&fromCityId={originCode}&oneway={!_Sc.IsRt }" +
                (_Sc.IsRt ? $"&retDate={_Sc.InboundDate:yyyy-MM-dd}" : string.Empty) +
                $"&searchType=AIR&serviceClass={pageCabin}&toCityId={destinationCode}&tripType=" +
                (_Sc.IsRt ? "TRIP_TYPE_RETURN" : "TRIP_TYPE_ONEWAY") +
                $"&visualDepartureDate={_Sc.OutboundDate:yyyy-MM-dd}&visualReturnDate={_Sc.InboundDate:yyyy-MM-dd}";
        }
        private List<JToken> ExtractRecommendations(JToken flightsPageJson)
        {
            try
            {
                return flightsPageJson.SelectToken("prepopulatedResponse.result.tripMap").Children().ToList();
            }
            catch (Exception e)
            {
                return new List<JToken>();
            }
        }
        private bool TryExtractBound(JToken recommendation, out JToken extractedBound, bool isOutbound = true)
        {
            extractedBound = null;

            try
            {
                extractedBound = isOutbound
                    ? recommendation.First().SelectToken("bounds").First()
                    : recommendation.First().SelectToken("bounds").Last();

                return extractedBound != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private bool ExtractData(JToken sectorInfo, out Flight extractedFlight)
        {
            extractedFlight = null;
            JToken legs = sectorInfo.SelectToken("segments");

            if (legs.Count() > 2)
            {
                return false;
            }

            string origin = null;
            string connection = null;
            string destination = null;
            string departureDateTimeString = null;
            string arrivalDateTimeString = null;
            string flightNumber = string.Empty;
            string airline = string.Empty;
            char cabinClass = 'E';

            foreach (JToken singleLeg in legs)
            {
                bool isFirstLeg = singleLeg == legs.First();

                if (legs.Count() == 2)
                {
                    if (isFirstLeg)
                    {
                        origin = (string)singleLeg.SelectToken("from.airportIata");
                        connection = (string)singleLeg.SelectToken("to.airportIata");

                        departureDateTimeString = ((string)singleLeg.SelectToken("from.date.fullDate")).Replace("Tors", "Tor") + " " + (string)singleLeg.SelectToken("from.time");
                    }
                    else
                    {
                        destination = (string)singleLeg.SelectToken("to.airportIata");
                        arrivalDateTimeString = ((string)singleLeg.SelectToken("from.date.fullDate")).Replace("Tors", "Tor") + " " + (string)singleLeg.SelectToken("to.time");
                    }
                }
                else
                {
                    origin = (string)singleLeg.SelectToken("from.airportIata");
                    destination = (string)singleLeg.SelectToken("to.airportIata");

                    departureDateTimeString = ((string)singleLeg.SelectToken("from.date.fullDate")).Replace("Tors", "Tor") + " " + (string)singleLeg.SelectToken("from.time");
                    arrivalDateTimeString = ((string)singleLeg.SelectToken("from.date.fullDate")).Replace("Tors", "Tor") + " " + (string)singleLeg.SelectToken("to.time");
                }

                flightNumber += (string)singleLeg.SelectToken("flight.carrierCode") + (string)singleLeg.SelectToken("flight.flightNumber") + " ";

                if ((string)singleLeg.SelectToken("flight.cabinClass.code") != null)
                {
                    char cabinFromDictionary = Dictionaries.ToGuiCabinsSe[(string)singleLeg.SelectToken("flight.cabinClass.code")];

                    cabinClass = cabinFromDictionary;
                }

                if (cabinClass != _Sc.CabinClass)
                {
                    return false;
                }

                if (isFirstLeg)
                {
                    string[] airlineParts = ((string)singleLeg.SelectToken("flight.description")).Split();
                    airline = string.Join(" ", airlineParts.Take(airlineParts.Length - 1));
                }
                else
                {
                    string[] airlineParts = ((string)singleLeg.SelectToken("flight.description")).Split();

                    if (airline != string.Join(" ", airlineParts.Take(airlineParts.Length - 1)))
                    {
                        return false;
                    }
                }
            }

            extractedFlight = new Flight(origin, connection, destination, departureDateTimeString, arrivalDateTimeString, flightNumber, airline, cabinClass);

            return true;
        }
    }
}
