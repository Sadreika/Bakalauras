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

            List<ChartData> dataGridDataList = new List<ChartData>();

            for (int i = 1; i < airlineFlightsDataGridView.Rows.Count - 1; i++)
            {
                ChartData chartData = new ChartData((decimal)airlineFlightsDataGridView.Rows[i].Cells[24].Value, (DateTime)airlineFlightsDataGridView.Rows[i].Cells[7].Value, (string)airlineFlightsDataGridView.Rows[i].Cells[28].Value);
                dataGridDataList.Add(chartData);
            }

            List<List<ChartData>> chartDataList = ChartData.FilterChartList(dataGridDataList);

            List<string> fullDateList = new List<string>();
            fullDateList = dataGridDataList.Select(x => x.DateLabel).ToList();
            fullDateList = fullDateList.Distinct().ToList();

            compareCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Dienos",
                Labels = fullDateList
            });

            compareCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Kainos",
            });

            compareCartesianChart.Series.Clear();

            SeriesCollection series = new SeriesCollection();

            foreach (List<ChartData> chartData in chartDataList)
            {
                string chartName = chartData.First().Airline;
                series.Add(new LineSeries() { Title = chartName, Values = new ChartValues<decimal>(chartData.Select(x => x.Price).ToList()) });
            }

            compareCartesianChart.Series = series;
        }
    }
}
