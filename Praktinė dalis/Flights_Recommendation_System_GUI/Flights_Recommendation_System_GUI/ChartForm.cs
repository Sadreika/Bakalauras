namespace Flights_Recommendation_System_GUI
{
    using LiveCharts;
    using LiveCharts.Wpf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class ChartForm : Form
    {
        public ChartForm(double[][] chartData)
        {
            InitializeComponent();

            List<string> datesList = new List<string>();
            List<double> values = new List<double>();

            foreach(double[] data in chartData)
            {
                datesList.Add($"{data[0]} {data[1]} {data[2]}");
                values.Add(data[3]);
            }

            currencyCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Dienos",
                Labels = datesList
            });

            currencyCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Kursas"
            });

            currencyCartesianChart.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            series.Add(new LineSeries() { Title = "Kursas", Values = new ChartValues<double>(values)});
            currencyCartesianChart.Series = series;
            //currencyCartesianChart.Series.AddRange(values);
        }
    }
}
