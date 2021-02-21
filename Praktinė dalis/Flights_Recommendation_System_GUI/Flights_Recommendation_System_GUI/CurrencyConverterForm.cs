namespace Flights_Recommendation_System_GUI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using Currency_crawler;
    public partial class CurrencyConverterForm : Form
    {
        private MainForm Mainform { get; set; }

        private DataTable Data;

        private List<string> ValueList = new List<string>();
        private List<string> DisplayList = new List<string>();
        private List<string> SearchList = new List<string>();

        private ChartForm chartForm;
        public CurrencyConverterForm (MainForm mainform, string currency, DataTable currenciesFromDatabase)
        {
            this.Mainform = mainform;
            mainform.Enabled = false;

            InitializeComponent();

            convertProgressBar.Visible = false;
            rateLabel.Visible = false;
            ValueList = currenciesFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Value")).ToList();
            DisplayList = currenciesFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Display")).ToList();
            SearchList = currenciesFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Search")).ToList();

            currentCurrencyTextBox.Text = currency;
            SetLocationsDataGridViewData();
        }

        private void SetLocationsDataGridViewData()
        {
            Data = new DataTable();

            Data.Columns.Add("Valiutos trumpinys");
            Data.Columns.Add("Valiutos pilnas pavadinimas");

            for (int i = 0; i < ValueList.Count; i++)
            {
                if (newCurrencyTextBox.Text != null)
                {
                    if (SearchList[i].ToLower().Contains(newCurrencyTextBox.Text.ToLower()))
                    {
                        Data.Rows.Add(ValueList[i], DisplayList[i]);
                    }
                }
            }

            currenciesDataGridView.DataSource = Data;
        }

        private void CurrencyConverterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mainform.Enabled = true;
            if(chartForm != null)
            {
                chartForm.Close();
            }
        }

        private void newCurrencyTextBox_TextChanged(object sender, System.EventArgs e)
        {
            SetLocationsDataGridViewData();
            rateLabel.Visible = false;
        }

        private void currenciesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.currenciesDataGridView.Rows[e.RowIndex];
                newCurrencyTextBox.Text = Data.Rows[row.Index][0].ToString();
                rateLabel.Visible = false;
            }
        }

        private void conversionInfoButton_Click(object sender, System.EventArgs e)
        {
            if(CheckCurrency())
            {
                Crawler crawler = new Crawler();
                crawler.StartConversionCrawler(newCurrencyTextBox.Text.ToUpper(), currentCurrencyTextBox.Text.ToUpper(), out double tradeRate, out double[][] chartData);
                rateLabel.Visible = true;
                rateLabel.Text = $"Santykis: {Math.Round(tradeRate, 2)}";

                chartForm = new ChartForm(chartData);
                chartForm.StartPosition = FormStartPosition.Manual;

                chartForm.Left = this.Location.X + this.Size.Width;
                chartForm.Top = this.Location.Y;

                chartForm.Show();
            }
        }

        private void convertButton_Click(object sender, System.EventArgs e)
        {
            Crawler crawler = new Crawler();
            crawler.StartConversionCrawler(newCurrencyTextBox.Text.ToUpper(), currentCurrencyTextBox.Text.ToUpper(), out double tradeRate, out double[][] chartData);
            Mainform.Enabled = true;
            Mainform.TradeRate = tradeRate;
            convertProgressBar.Visible = true;
            Mainform.ChangeCurrency(newCurrencyTextBox.Text, convertProgressBar);
            Mainform.TradeRate = null;
            if (chartForm != null)
            {
                chartForm.Close();
            }
            Close();
        }

        private bool CheckCurrency()
        {
            return ValueList.Contains(newCurrencyTextBox.Text.ToUpper());
        }
    }
}
