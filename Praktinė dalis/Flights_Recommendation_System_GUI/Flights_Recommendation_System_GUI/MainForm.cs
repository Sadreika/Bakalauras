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
        private List<string> AirportSuggestionsList;
        private List<string> CitySuggestionsList;
        private List<string> CountrySuggestionsList;
        private List<string> IATASuggestionsList;
        private List<string> AllSuggestionsList = new List<string>();
        private AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
        
        public MainForm()
        {
            InitializeComponent();
            LoadAirports();
        }

        private void LoadAirports()
        {
            Datasave.StartConnection();
            if(Datasave.TryGetDataFromTable("Airports", "*", out DataTable dataFromDatabase))
            {
                AirportSuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Airport")).ToList();
                CitySuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("City")).ToList();
                CountrySuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Country")).ToList();
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
            
        }

        private void arrivalAirportTextBox_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
