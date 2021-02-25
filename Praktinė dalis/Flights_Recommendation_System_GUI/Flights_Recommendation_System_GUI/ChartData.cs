namespace Flights_Recommendation_System_GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChartData
    {
        public decimal Price;
        public DateTime Date;
        public string DateLabel;
        public ChartData()
        {

        }
        public ChartData(decimal price, DateTime date)
        {
            Price = price;
            Date = date;
        }
        public ChartData(decimal price, string dateLabel)
        {
            Price = price;
            DateLabel = dateLabel;
        }
        public List<ChartData> FilterChartList(List<ChartData> chartDataList)
        {
            for(int i = 0; i < chartDataList.Count; i++)
            {
                chartDataList[i].DateLabel = chartDataList[i].Date.ToString("yyyy MM dd");
            }

            List<ChartData> newChartDataList = new List<ChartData>();

            for (int i = 0; i < chartDataList.Count; i++)
            {
                decimal cheapestPrice = chartDataList[i].Price;

                for (int j = i + 1; j < chartDataList.Count - 1; j++)
                {
                    if(chartDataList[i].DateLabel == chartDataList[j].DateLabel)
                    {
                        if(chartDataList[i].Price < chartDataList[j].Price)
                        {
                            cheapestPrice = chartDataList[i].Price;
                        }
                    }
                }

                ChartData chartDate = new ChartData(cheapestPrice, chartDataList[i].DateLabel);
                newChartDataList.Add(chartDate);
            }

            return newChartDataList.GroupBy(x => x.DateLabel).Select(x => x.FirstOrDefault()).ToList();
        }
    }
}
