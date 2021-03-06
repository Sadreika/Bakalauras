namespace Flights_Recommendation_System_GUI
{
    using MoreLinq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChartData
    {
        public decimal Price;
        public DateTime Date;
        public string DateLabel;
        public string Airline;
        public ChartData()
        {

        }
        public ChartData(decimal price, DateTime date, string airline)
        {
            Price = price;
            Date = date;
            Airline = airline;
        }
        public ChartData(decimal price, string dateLabel)
        {
            Price = price;
            DateLabel = dateLabel;
        }
        public static List<List<ChartData>> FilterChartList(List<ChartData> chartDataList)
        {
            for(int i = 0; i < chartDataList.Count; i++)
            {
                chartDataList[i].DateLabel = chartDataList[i].Date.ToString("yyyy MM dd");
            }

            List<List<ChartData>> tempNewList = new List<List<ChartData>>();
            List<List<ChartData>> newList = new List<List<ChartData>>();

            List<string> airlines = chartDataList.Select(x => x.Airline).Distinct().OrderBy(x => x).ToList();
      
            foreach (string airline in airlines)
            {
                List<ChartData> airlineData = new List<ChartData>();
                tempNewList.Add(airlineData);
            }

            for (int i = 0; i < chartDataList.Count; i++)
            {
                for(int j = 0; j < airlines.Count(); j++)
                {
                    if (chartDataList[i].Airline == airlines[j])
                    {
                        tempNewList[j].Add(chartDataList[i]);
                    }
                }  
            }

            foreach(List<ChartData> airlineChartDataList in tempNewList)
            {
                List<ChartData> filteredAirlineChartDataList = airlineChartDataList.OrderBy(x => x.Price).DistinctBy(x => x.DateLabel).ToList();
                newList.Add(filteredAirlineChartDataList);
            }

            return newList;
        }
    }
}
