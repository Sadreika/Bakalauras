namespace Flights_Recommendation_System_GUI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    public partial class LocationSelectionForm : Form
    {
        private MainForm Mainform { get; set; }
        private int SelectedRow { get; set; }
        private bool IsDeparture { get; set; }

        private DataTable Data;

        private List<string> AirportSuggestionsList = new List<string>();
        private List<string> CitySuggestionsList = new List<string>();
        private List<string> CountrySuggestionsList = new List<string>();
        private List<string> IATASuggestionsList = new List<string>();

        public LocationSelectionForm(MainForm mainform, DataTable dataFromDatabase, bool isDeparture)
        {
            this.Mainform = mainform;
            mainform.Enabled = false;

            InitializeComponent();
            countryRadioButton.Checked = true;

            AirportSuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Airport")).ToList();
            CitySuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("City")).ToList();
            CountrySuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Country")).ToList();
            IATASuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("IATA")).ToList();

            IsDeparture = isDeparture;

            SetLocationsDataGridViewData();
        }
        private void LocationSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mainform.Enabled = true;
        }
        private void SetLocationsDataGridViewData()
        {
            Data = new DataTable();

            Data.Columns.Add("Šalis");
            Data.Columns.Add("Miestas");
            Data.Columns.Add("Oro uostas");
            Data.Columns.Add("IATA");

            List<string> listToCheck;
            if (countryRadioButton.Checked)
            {
                listToCheck = CountrySuggestionsList;
            }
            else if (cityRadioButton.Checked)
            {
                listToCheck = CitySuggestionsList;
            }
            else
            {
                listToCheck = AirportSuggestionsList;
            }

            for (int i = 0; i < IATASuggestionsList.Count; i++)
            {
                if (locationTextBox.Text != null)
                {
                    if (listToCheck[i].ToLower().Contains(locationTextBox.Text.ToLower()))
                    {
                        Data.Rows.Add(CountrySuggestionsList[i], CitySuggestionsList[i], AirportSuggestionsList[i], IATASuggestionsList[i]);
                    }
                }
            }

            locationsDataGridView.DataSource = Data;
            locationsDataGridView.Columns[0].Width = 145;
            locationsDataGridView.Columns[1].Width = 145;
            locationsDataGridView.Columns[2].Width = 145;
            locationsDataGridView.Columns[3].Width = 50;

        }
        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            SetLocationsDataGridViewData();
        }
        private void countryRadioButton_Click(object sender, EventArgs e)
        {
            SetLocationsDataGridViewData();
        }
        private void cityRadioButton_Click(object sender, EventArgs e)
        {
            SetLocationsDataGridViewData();
        }
        private void airportRadioButton_Click(object sender, EventArgs e)
        {
            SetLocationsDataGridViewData();
        }
        private void locationsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.locationsDataGridView.Rows[e.RowIndex];
                SelectedRow = row.Index;
            }
        }
        private void locationsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Mainform.Enabled = true;
            Mainform.IATAToSet = Data.Rows[SelectedRow][3].ToString();
            Mainform.RefreshAirportTextBox(IsDeparture);
            Close();
        }
    }
}
