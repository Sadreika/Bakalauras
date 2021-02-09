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
        private DatasaveFunctions Datasave = new DatasaveFunctions(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True");
        private List<string> IATASuggestionsList;
        private AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
        private DataTable dataFromDatabase;

        public MainForm()
        {
            InitializeComponent();
            LoadAirports();
            PrepareComboBoxes();
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
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, dataFromDatabase);
            locationSelectionForm.Show();
        }

        private void arrivalAirportTextBox_DoubleClick(object sender, EventArgs e)
        {
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, dataFromDatabase);
            locationSelectionForm.Show();
        }

        private void PrepareComboBoxes()
        {
            string[] suggestionsArray = new string[] { "Ekonominė", "Verslo", "Premium", "Pirma" };
            classComboBox.Items.AddRange(suggestionsArray);
            Controls.Add(classComboBox);
        }
    }
}
