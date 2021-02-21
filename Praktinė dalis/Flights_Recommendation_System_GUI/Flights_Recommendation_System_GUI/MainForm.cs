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
        public double? TradeRate { get; set; }

        private DatasaveFunctions Datasave = new DatasaveFunctions(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True");

        private List<string> IATASuggestionsList;

        private AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();

        private DataTable airportsFromDatabase = new DataTable();
        private DataTable currenciesFromDatabase = new DataTable();

        public MainForm()
        {
            InitializeComponent();
            LoadAirports();
            LoadCurrencies();
            LoadAirlinesTablesNames();
            PrepareComboBoxes();
            PrepareCheckListBox();
            OWRTcheckBox.Checked = true;
        }
        public void RefreshAirportTextBox(bool isDepartureAirport)
        {
            if (isDepartureAirport)
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
            if (Datasave.TryGetDataFromTable("Airports", "*", out airportsFromDatabase))
            {
                IATASuggestionsList = airportsFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("IATA")).ToList();

                Collection.AddRange(IATASuggestionsList.ToArray());

                departureAirportTextBox.AutoCompleteCustomSource = Collection;
                arrivalAirportTextBox.AutoCompleteCustomSource = Collection;
            }

            Datasave.EndConnection();
        }
        private void LoadCurrencies()
        {
            Datasave.StartConnection();
            Datasave.TryGetDataFromTable("Currencies", "*", out currenciesFromDatabase);
            Datasave.EndConnection();
        }
        private void LoadAirlinesTablesNames()
        {
            Datasave.StartConnection();

            DataTable tables = Datasave.Connection.GetSchema("Tables");
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            for (int i = 0; i < tables.Rows.Count; i++)
            {
                if(tables.Rows[i].ItemArray[2].ToString() != "Currencies" &&
                    tables.Rows[i].ItemArray[2].ToString() != "Airports")
                {
                    collection.Add(tables.Rows[i].ItemArray[2].ToString());
                }
            }

            
           
            airlineTextBox.AutoCompleteCustomSource = collection;

            Datasave.EndConnection();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void departureAirportTextBox_DoubleClick(object sender, EventArgs e)
        {
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, airportsFromDatabase, true);
            locationSelectionForm.Show();
        }
        private void arrivalAirportTextBox_DoubleClick(object sender, EventArgs e)
        {
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, airportsFromDatabase, false);
            locationSelectionForm.Show();
        }
        private void PrepareComboBoxes()
        {
            string[] suggestionsArray = new string[] { "Ekonominė", "Verslo", "Premium", "Pirma" };
            classComboBox.Items.AddRange(suggestionsArray);
            Controls.Add(classComboBox);
        }
        private void PrepareCheckListBox()
        {
            filterCheckedListBox.Items.Add("Rodyti sustojimus");
            filterCheckedListBox.Items.Add("Rodyti skrydžio numerį");
            filterCheckedListBox.Items.Add("Rodyti skrydžio kategoriją");
            filterCheckedListBox.Items.Add("Rodyti klasę");
            filterCheckedListBox.Items.Add("Rodyti avialiniją");
            filterCheckedListBox.Enabled = false;
        }
        private void OWRTcheckBox_Click(object sender, EventArgs e)
        {
            if (OWRTcheckBox.Checked)
            {
                arrivalDateTimePicker.Enabled = true;
            }
            else
            {
                arrivalDateTimePicker.Enabled = false;
            }
        }
        private void collectedDataButton_Click(object sender, EventArgs e)
        {
            TryFillAirlineFlightsDataGridView(airlineTextBox.Text);
            filterCheckedListBox.Enabled = true;
        }
        private bool TryFillAirlineFlightsDataGridView(string tableName)
        {
            Datasave.StartConnection();

            if (Datasave.TryGetDataFromTable(tableName, "*", out DataTable dataFromDatabase))
            {
                airlineFlightsDataGridView.DataSource = dataFromDatabase;
                ChangeAirlineFlightsDataGridViewHeaders();

                Datasave.Connection.Close();
                return true;
            }

            Datasave.EndConnection();

            return false;
        }
        private void ChangeAirlineFlightsDataGridViewHeaders()
        {
            //outbound
            airlineFlightsDataGridView.Columns[0].Visible = false;
            airlineFlightsDataGridView.Columns[3].Visible = false;
            airlineFlightsDataGridView.Columns[10].Visible = false;
            airlineFlightsDataGridView.Columns[11].Visible = false;
            airlineFlightsDataGridView.Columns[14].Visible = false;
            airlineFlightsDataGridView.Columns[21].Visible = false;
            airlineFlightsDataGridView.Columns[22].Visible = false;
            airlineFlightsDataGridView.Columns[27].Visible = false;
            airlineFlightsDataGridView.Columns[28].Visible = false;

            airlineFlightsDataGridView.Columns[1].HeaderText = "Išvykimo IATA";
            airlineFlightsDataGridView.Columns[2].HeaderText = "Atvykimo IATA";
            airlineFlightsDataGridView.Columns[3].HeaderText = "Sustojimo IATA";
            airlineFlightsDataGridView.Columns[4].HeaderText = "Kaina be mokesčių";
            airlineFlightsDataGridView.Columns[5].HeaderText = "Pilna kaina";
            airlineFlightsDataGridView.Columns[6].HeaderText = "Mokestis";
            airlineFlightsDataGridView.Columns[7].HeaderText = "Išvykimo laikas";
            airlineFlightsDataGridView.Columns[8].HeaderText = "Atvykimo laikas";
            airlineFlightsDataGridView.Columns[9].HeaderText = "Kelionės trukmė";
            airlineFlightsDataGridView.Columns[10].HeaderText = "Skrydžio kategorija";
            airlineFlightsDataGridView.Columns[11].HeaderText = "Skrydžio numeris";

            //inbound

            airlineFlightsDataGridView.Columns[12].HeaderText = "Išvykimo IATA";
            airlineFlightsDataGridView.Columns[13].HeaderText = "Atvykimo IATA";
            airlineFlightsDataGridView.Columns[14].HeaderText = "Sustojimo IATA";
            airlineFlightsDataGridView.Columns[15].HeaderText = "Kaina be mokesčių";
            airlineFlightsDataGridView.Columns[16].HeaderText = "Pilna kaina";
            airlineFlightsDataGridView.Columns[17].HeaderText = "Mokestis";
            airlineFlightsDataGridView.Columns[18].HeaderText = "Išvykimo laikas";
            airlineFlightsDataGridView.Columns[19].HeaderText = "Atvykimo laikas";
            airlineFlightsDataGridView.Columns[20].HeaderText = "Kelionės trukmė";
            airlineFlightsDataGridView.Columns[21].HeaderText = "Skrydžio kategorija";
            airlineFlightsDataGridView.Columns[22].HeaderText = "Skrydžio numeris";

            airlineFlightsDataGridView.Columns[23].HeaderText = "Visos kelionės kaina be mokesčių";
            airlineFlightsDataGridView.Columns[24].HeaderText = "Visos kelionės kaina";
            airlineFlightsDataGridView.Columns[25].HeaderText = "Visos kelionės mokesčiai";

            airlineFlightsDataGridView.Columns[26].HeaderText = "Valiuta";
            airlineFlightsDataGridView.Columns[27].HeaderText = "Klasė";
            airlineFlightsDataGridView.Columns[28].HeaderText = "Avialinija";
        }
        private void filterCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool valueToSet = false;

            switch (filterCheckedListBox.SelectedIndex)
            {
                case 0:
                    valueToSet = airlineFlightsDataGridView.Columns[3].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[3].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[14].Visible = valueToSet;
                    break;
                case 1:
                    valueToSet = airlineFlightsDataGridView.Columns[22].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[11].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[22].Visible = valueToSet;
                    break;
                case 2:
                    valueToSet = airlineFlightsDataGridView.Columns[21].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[10].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[21].Visible = valueToSet;
                    break;
                case 3:
                    valueToSet = airlineFlightsDataGridView.Columns[27].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[27].Visible = valueToSet;
                    break;
                case 4:
                    valueToSet = airlineFlightsDataGridView.Columns[28].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[28].Visible = valueToSet;
                    break;
            }

            filterCheckedListBox.SetItemChecked(filterCheckedListBox.SelectedIndex, valueToSet);

            filterCheckedListBox.Refresh();
            airlineFlightsDataGridView.Update();
            airlineFlightsDataGridView.Refresh();
        }
        private void airlineFlightsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cellSelected = airlineFlightsDataGridView.SelectedCells;
            int columnIndex = cellSelected[0].ColumnIndex;
            string cellValue = cellSelected[0].Value.ToString();

            if (columnIndex == 1 || columnIndex == 2 || columnIndex == 3 ||
               columnIndex == 12 || columnIndex == 13 || columnIndex == 14)
            {
                IATAInformationForm iATAInformationForm = new IATAInformationForm(airportsFromDatabase, cellValue);
                iATAInformationForm.StartPosition = FormStartPosition.Manual;

                var cellRectangle = airlineFlightsDataGridView.GetCellDisplayRectangle(cellSelected[0].ColumnIndex, cellSelected[0].RowIndex, true);

                iATAInformationForm.Left = cellRectangle.Left;
                iATAInformationForm.Top = cellRectangle.Bottom + 170;
                iATAInformationForm.Show();
            }

            if (columnIndex == 4 || columnIndex == 5 || columnIndex == 6 ||
                columnIndex == 15 || columnIndex == 16 || columnIndex == 17 ||
                columnIndex == 23 || columnIndex == 24 || columnIndex == 25)
            {
                CurrencyConverterForm currencyConverterForm = new CurrencyConverterForm(this, airlineFlightsDataGridView.Rows[cellSelected[0].RowIndex].Cells[26].Value.ToString(), currenciesFromDatabase);
                currencyConverterForm.Show();
            }
        }
        public void ChangeCurrency(string newCurrency, ProgressBar convertProgressBar)
        {
            List<int> columnsIds = new List<int>() { 4, 5, 6, 15, 16, 17, 23, 24, 25 };

            convertProgressBar.Maximum = airlineFlightsDataGridView.Rows.Count - 1;
            for (int i = 0; i < airlineFlightsDataGridView.Rows.Count - 1; i++)
            {
                foreach (int columnId in columnsIds)
                {
                    airlineFlightsDataGridView.Rows[i].Cells[columnId].Value = airlineFlightsDataGridView.Rows[i].Cells[columnId].Value.ToString() != string.Empty
                         ? Math.Round((decimal)airlineFlightsDataGridView.Rows[i].Cells[columnId].Value * (decimal)TradeRate, 2)
                         : airlineFlightsDataGridView.Rows[i].Cells[columnId].Value;
                }

                airlineFlightsDataGridView.Rows[i].Cells[26].Value = newCurrency.ToUpper();
                convertProgressBar.Increment(1);
            }


            airlineFlightsDataGridView.Update();
            airlineFlightsDataGridView.Refresh();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
