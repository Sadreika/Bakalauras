namespace Flights_Recommendation_System_GUI
{
    using Flights_Recommendation_System_GUI.Functions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    public partial class MainForm : Form
    {
        public string IATAToSet { get; set; }

        private DatasaveFunctions Datasave = new DatasaveFunctions(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True");
        
        private List<string> IATASuggestionsList;

        private AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
        private DataTable dataFromDatabase;

        public MainForm()
        {
            InitializeComponent();
            LoadAirports();
            PrepareComboBoxes();
            OWRTcheckBox.Checked = true;
        }
        public void RefreshAirportTextBox(bool isDepartureAirport)
        {
            if(isDepartureAirport)
            {
                departureAirportTextBox.Text = IATAToSet;
            }
            else
            {
                arrivalAirportTextBox.Text = IATAToSet;
            }
        }
        private void LoadAirports()
        {
            Datasave.StartConnection();
            if(Datasave.TryGetDataFromTable("Airports", "*", out dataFromDatabase))
            {
                IATASuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("IATA")).ToList();

                Collection.AddRange(IATASuggestionsList.ToArray());

                departureAirportTextBox.AutoCompleteCustomSource = Collection;
                arrivalAirportTextBox.AutoCompleteCustomSource = Collection;
            }

            Datasave.EndConnection();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void departureAirportTextBox_DoubleClick(object sender, EventArgs e)
        {
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, dataFromDatabase, true);
            locationSelectionForm.Show();
        }
        private void arrivalAirportTextBox_DoubleClick(object sender, EventArgs e)
        {
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, dataFromDatabase, false);
            locationSelectionForm.Show();
        }
        private void PrepareComboBoxes()
        {
            string[] suggestionsArray = new string[] { "Ekonominė", "Verslo", "Premium", "Pirma" };
            classComboBox.Items.AddRange(suggestionsArray);
            Controls.Add(classComboBox);
        }
        private void OWRTcheckBox_Click(object sender, EventArgs e)
        {
            if(OWRTcheckBox.Checked)
            {
                arrivalDateTimePicker.Enabled = true;
            }
            else
            {
                arrivalDateTimePicker.Enabled = false;
            }
        }

        private void allFlightsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
