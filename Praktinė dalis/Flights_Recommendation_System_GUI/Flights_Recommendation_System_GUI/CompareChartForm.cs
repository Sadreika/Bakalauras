namespace Flights_Recommendation_System_GUI
{
    using LiveCharts;
    using LiveCharts.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    public partial class CompareChartForm : Form
    {
        public CompareChartForm(DataGridView airlineFlightsDataGridView)
        {
            InitializeComponent();
            // reikia maziausiu kainu saraso
            // reikia atskiro grafo inboundui ir atskiro outboundui
            List<decimal> priceList = new List<decimal>();
            List<DateTime> tempDateList = new List<DateTime>();

            for (int i = 1; i < airlineFlightsDataGridView.Rows.Count - 1; i++)
            {
                priceList.Add((decimal)airlineFlightsDataGridView.Rows[i].Cells[5].Value);
                tempDateList.Add((DateTime)airlineFlightsDataGridView.Rows[i].Cells[7].Value);

                if (airlineFlightsDataGridView.Rows[i].Cells[16].Value != null)
                {
                    priceList.Add((decimal)airlineFlightsDataGridView.Rows[i].Cells[16].Value);
                    tempDateList.Add((DateTime)airlineFlightsDataGridView.Rows[i].Cells[19].Value);
                }
            }

            tempDateList.Sort();

            List<string> dateList = new List<string>();
            dateList.AddRange(tempDateList.Select(x => x.ToString("yyyy MM dd")));
            dateList = dateList.Distinct().ToList();

            compareCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Dienos",
                Labels = dateList
            });

            compareCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Kainos",
            });

            compareCartesianChart.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            series.Add(new LineSeries() { Title = "Kaina", Values = new ChartValues<decimal>(priceList) });
            compareCartesianChart.Series = series;
        }
    }
}
