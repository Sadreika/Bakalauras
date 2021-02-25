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

            ChartData chartData = new ChartData();

            List<ChartData> outboundChartDataList = new List<ChartData>();
            List<ChartData> inboundChartDataList = new List<ChartData>();

            for (int i = 1; i < airlineFlightsDataGridView.Rows.Count - 1; i++)
            {
                ChartData outboundChartData = new ChartData((decimal)airlineFlightsDataGridView.Rows[i].Cells[5].Value, (DateTime)airlineFlightsDataGridView.Rows[i].Cells[7].Value);
                outboundChartDataList.Add(outboundChartData);

                if (airlineFlightsDataGridView.Rows[i].Cells[16].Value != null)
                {
                    ChartData inboundChartData = new ChartData((decimal)airlineFlightsDataGridView.Rows[i].Cells[16].Value, (DateTime)airlineFlightsDataGridView.Rows[i].Cells[19].Value);
                    inboundChartDataList.Add(inboundChartData);
                }
            }

            outboundChartDataList = chartData.FilterChartList(outboundChartDataList);
            inboundChartDataList = chartData.FilterChartList(inboundChartDataList);

            List<string> fullDateList = new List<string>();
            fullDateList = outboundChartDataList.Select(x => x.DateLabel).ToList();

            outboundCompareCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Dienos",
                Labels = fullDateList
            });

            outboundCompareCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Kainos",
            });

            fullDateList = inboundChartDataList.Select(x => x.DateLabel).ToList();

            inboundCompareCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Dienos",
                Labels = fullDateList
            });

            inboundCompareCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Kainos",
            });

            outboundCompareCartesianChart.Series.Clear();
            inboundCompareCartesianChart.Series.Clear();

            SeriesCollection outboundSeries = new SeriesCollection();
            SeriesCollection inboundSeries = new SeriesCollection();

            outboundSeries.Add(new LineSeries() { Title = "Išvykimo kaina", Values = new ChartValues<decimal>(outboundChartDataList.Select(x => x.Price).ToList())});

            outboundCompareCartesianChart.Series = outboundSeries;

            inboundSeries.Add(new LineSeries() { Title = "Grįžimo kaina", Values = new ChartValues<decimal>(inboundChartDataList.Select(x => x.Price).ToList())});

            inboundCompareCartesianChart.Series = inboundSeries;
        }
    }
}
