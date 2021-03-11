namespace Flights_Recommendation_System_GUI
{
    using Functions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    public partial class MainForm : Form
    {
        public string IATAToSet { get; set; }
        public double? TradeRate { get; set; }

        private DatasaveFunctions Datasave = new DatasaveFunctions(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=FlightsRecommendationSystemDatabase;Integrated Security=True");

        private List<string> IATASuggestionsList;

        private AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();

        private DataTable _airportsFromDatabase = new DataTable();
        private DataTable _currenciesFromDatabase = new DataTable();
        public MainForm()
        {
            InitializeComponent();
            PrepareCalendar();
            LoadAirports();
            LoadCurrencies();
            LoadAirlinesTablesNames();
            PrepareComboBoxes();
            PrepareCheckListBox();
            OWRTcheckBox.Checked = true;
        }
        private void PrepareCalendar()
        {
            arrivalDateTimePicker.MinDate = DateTime.Now;
            departureDateTimePicker.MinDate = DateTime.Now;
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
            if (Datasave.TryGetDataFromTable("Airports", "*", out _airportsFromDatabase))
            {
                IATASuggestionsList = _airportsFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("IATA")).ToList();

                Collection.AddRange(IATASuggestionsList.ToArray());

                departureAirportTextBox.AutoCompleteCustomSource = Collection;
                arrivalAirportTextBox.AutoCompleteCustomSource = Collection;
            }

            Datasave.EndConnection();
        }
        private void LoadCurrencies()
        {
            Datasave.StartConnection();
            Datasave.TryGetDataFromTable("Currencies", "*", out _currenciesFromDatabase);
            Datasave.EndConnection();
        }
        private void LoadAirlinesTablesNames()
        {
            Datasave.StartConnection();

            DataTable tables = Datasave.Connection.GetSchema("Tables");
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            for (int i = 0; i < tables.Rows.Count; i++)
            {
                if (tables.Rows[i].ItemArray[2].ToString() != "Currencies" &&
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
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, _airportsFromDatabase, true);
            locationSelectionForm.Show();
        }
        private void arrivalAirportTextBox_DoubleClick(object sender, EventArgs e)
        {
            LocationSelectionForm locationSelectionForm = new LocationSelectionForm(this, _airportsFromDatabase, false);
            locationSelectionForm.Show();
        }
        private void PrepareComboBoxes()
        {
            object[] suggestionsArray = { "Ekonominė", "Verslo", "Premium", "Pirma" };
            classComboBox.Items.AddRange(suggestionsArray);
            Controls.Add(classComboBox);
            classComboBox.Text = "Ekonominė";
        }
        private void PrepareCheckListBox()
        {
            filterCheckedListBox.Items.Add("Rodyti tarpines kainas");
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
            if (!ErrorNotification())
            {
                if (TryFillAirlineFlightsDataGridView(true))
                {
                    filterCheckedListBox.Enabled = true;
                }
                CalculateFlightByStopsCount();
            }
        }
        private bool TryFillAirlineFlightsDataGridView(bool isSearch)
        {
            string query;

            Datasave.StartConnection();

            if (airlineTextBox.Text != string.Empty)
            {
                query = Datasave.ConstructSelectionString(airlineTextBox.Text, departureAirportTextBox.Text, arrivalAirportTextBox.Text,
                    departureDateTimePicker.Text, arrivalDateTimePicker.Text, OWRTcheckBox.Checked, classComboBox.Text, lowestPriceTextBox.Text,
                    biggestPriceTextBox.Text, hoursNumericUpDown.Value.ToString(), minutesNumericUpDown.Value.ToString(),
                    zeroStopsCheckBox.Checked, oneStopCheckBox.Checked, isSearch);

                if (Datasave.TryGetDataFromTableCustom(query, out DataTable dataFromDatabase))
                {
                    airlineFlightsDataGridView.DataSource = dataFromDatabase;

                    Datasave.EndConnection();
                    ChangeAirlineFlightsDataGridViewHeaders();
                    return true;
                }
            }
            else
            {
                DataTable allDataFromDatabase = new DataTable();
                foreach (var tableName in airlineTextBox.AutoCompleteCustomSource)
                {
                    query = Datasave.ConstructSelectionString(tableName.ToString(), departureAirportTextBox.Text, arrivalAirportTextBox.Text,
                        departureDateTimePicker.Text, arrivalDateTimePicker.Text, OWRTcheckBox.Checked, classComboBox.Text, lowestPriceTextBox.Text,
                    biggestPriceTextBox.Text, hoursNumericUpDown.Value.ToString(), minutesNumericUpDown.Value.ToString(),
                    zeroStopsCheckBox.Checked, oneStopCheckBox.Checked, isSearch);

                    if (Datasave.TryGetDataFromTableCustom(query, out DataTable dataFromDatabase))
                    {
                        if (dataFromDatabase.Rows.Count != 0)
                        {
                            allDataFromDatabase.Merge(dataFromDatabase);
                        }
                    }
                }

                if (allDataFromDatabase.Rows.Count != 0)
                {
                    airlineFlightsDataGridView.DataSource = allDataFromDatabase;
                    ChangeAirlineFlightsDataGridViewHeaders();
                    Datasave.EndConnection();
                    return true;
                }
            }

            Datasave.EndConnection();

            return false;
        }
        private void ChangeAirlineFlightsDataGridViewHeaders()
        {
            airlineFlightsDataGridView.Columns[0].Visible = false;
            airlineFlightsDataGridView.Columns[3].Visible = false;
            airlineFlightsDataGridView.Columns[4].Visible = false;
            airlineFlightsDataGridView.Columns[5].Visible = false;
            airlineFlightsDataGridView.Columns[6].Visible = false;
            airlineFlightsDataGridView.Columns[10].Visible = false;
            airlineFlightsDataGridView.Columns[11].Visible = false;
            airlineFlightsDataGridView.Columns[14].Visible = false;
            airlineFlightsDataGridView.Columns[15].Visible = false;
            airlineFlightsDataGridView.Columns[16].Visible = false;
            airlineFlightsDataGridView.Columns[17].Visible = false;
            airlineFlightsDataGridView.Columns[21].Visible = false;
            airlineFlightsDataGridView.Columns[22].Visible = false;
            airlineFlightsDataGridView.Columns[27].Visible = false;
            airlineFlightsDataGridView.Columns[28].Visible = false;

            airlineFlightsDataGridView.Columns[1].HeaderText = @"Išvykimo IATA";
            airlineFlightsDataGridView.Columns[2].HeaderText = @"Atvykimo IATA";
            airlineFlightsDataGridView.Columns[3].HeaderText = @"Sustojimo IATA";
            airlineFlightsDataGridView.Columns[4].HeaderText = @"Kaina be mokesčių";
            airlineFlightsDataGridView.Columns[5].HeaderText = @"Pilna kaina";
            airlineFlightsDataGridView.Columns[6].HeaderText = @"Mokestis";
            airlineFlightsDataGridView.Columns[7].HeaderText = @"Išvykimo laikas";
            airlineFlightsDataGridView.Columns[8].HeaderText = @"Atvykimo laikas";
            airlineFlightsDataGridView.Columns[9].HeaderText = @"Kelionės trukmė";
            airlineFlightsDataGridView.Columns[10].HeaderText = @"Skrydžio kategorija";
            airlineFlightsDataGridView.Columns[11].HeaderText = @"Skrydžio numeris";
            airlineFlightsDataGridView.Columns[12].HeaderText = @"Išvykimo IATA";
            airlineFlightsDataGridView.Columns[13].HeaderText = @"Atvykimo IATA";
            airlineFlightsDataGridView.Columns[14].HeaderText = @"Sustojimo IATA";
            airlineFlightsDataGridView.Columns[15].HeaderText = @"Kaina be mokesčių";
            airlineFlightsDataGridView.Columns[16].HeaderText = @"Pilna kaina";
            airlineFlightsDataGridView.Columns[17].HeaderText = @"Mokestis";
            airlineFlightsDataGridView.Columns[18].HeaderText = @"Išvykimo laikas";
            airlineFlightsDataGridView.Columns[19].HeaderText = @"Atvykimo laikas";
            airlineFlightsDataGridView.Columns[20].HeaderText = @"Kelionės trukmė";
            airlineFlightsDataGridView.Columns[21].HeaderText = @"Skrydžio kategorija";
            airlineFlightsDataGridView.Columns[22].HeaderText = @"Skrydžio numeris";

            airlineFlightsDataGridView.Columns[23].HeaderText = @"Visos kelionės kaina be mokesčių";
            airlineFlightsDataGridView.Columns[24].HeaderText = @"Visos kelionės kaina";
            airlineFlightsDataGridView.Columns[25].HeaderText = @"Visos kelionės mokesčiai";

            airlineFlightsDataGridView.Columns[26].HeaderText = @"Valiuta";
            airlineFlightsDataGridView.Columns[27].HeaderText = @"Klasė";
            airlineFlightsDataGridView.Columns[28].HeaderText = @"Avialinija";
        }
        private void filterCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool valueToSet = false;

            switch (filterCheckedListBox.SelectedIndex)
            {
                case 0:
                    valueToSet = airlineFlightsDataGridView.Columns[4].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[4].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[5].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[6].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[15].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[16].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[17].Visible = valueToSet;
                    break;
                case 1:
                    valueToSet = airlineFlightsDataGridView.Columns[3].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[3].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[14].Visible = valueToSet;
                    break;
                case 2:
                    valueToSet = airlineFlightsDataGridView.Columns[22].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[11].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[22].Visible = valueToSet;
                    break;
                case 3:
                    valueToSet = airlineFlightsDataGridView.Columns[21].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[10].Visible = valueToSet;
                    airlineFlightsDataGridView.Columns[21].Visible = valueToSet;
                    break;
                case 4:
                    valueToSet = airlineFlightsDataGridView.Columns[27].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[27].Visible = valueToSet;
                    break;
                case 5:
                    valueToSet = airlineFlightsDataGridView.Columns[28].Visible == true ? false : true;
                    airlineFlightsDataGridView.Columns[28].Visible = valueToSet;
                    break;
            }

            filterCheckedListBox.SetItemChecked(filterCheckedListBox.SelectedIndex, valueToSet);

            filterCheckedListBox.Refresh();
            airlineFlightsDataGridView.Update();
            airlineFlightsDataGridView.Refresh();
        }
        public void ChangeCurrency(string newCurrency, ProgressBar convertProgressBar)
        {
            List<int> columnsIds = new List<int>() { 4, 5, 6, 15, 16, 17, 23, 24, 25 };

            convertProgressBar.Maximum = airlineFlightsDataGridView.Rows.Count - 1;
            for (int i = 0; i < airlineFlightsDataGridView.Rows.Count - 1; i++)
            {
                foreach (int columnId in columnsIds)
                {
                    if (TradeRate != null)
                        airlineFlightsDataGridView.Rows[i].Cells[columnId].Value =
                            airlineFlightsDataGridView.Rows[i].Cells[columnId].Value.ToString() != string.Empty
                                ? Math.Round(
                                    (decimal)airlineFlightsDataGridView.Rows[i].Cells[columnId].Value *
                                    (decimal)TradeRate, 2)
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
            string flightType = OWRTcheckBox.Checked ? "R" : "O";
            string connectionCount = directFlightCheckBox.Checked ? "1" : "0";

            if (!ErrorNotification())
            {
                Process compiler = new Process();

                compiler.StartInfo.FileName = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Crawlers\\") + $"{airlineTextBox.Text}.exe";

                compiler.StartInfo.Arguments = $"\"{departureAirportTextBox.Text.ToUpper()}|{arrivalAirportTextBox.Text.ToUpper()}|" +
                   $"{departureDateTimePicker.Value.ToString("yyyy")}|" +
                   $"{departureDateTimePicker.Value.ToString("MM")}|" +
                   $"{departureDateTimePicker.Value.ToString("dd")}|" +
                   $"{arrivalDateTimePicker.Value.ToString("yyyy")}|" +
                   $"{arrivalDateTimePicker.Value.ToString("MM")}|" +
                   $"{arrivalDateTimePicker.Value.ToString("dd")}|" +
                   $"{Dictionary.TravelClassesDictionary[classComboBox.Text]}|" +
                   $"{flightType}||{connectionCount}\"";

                compiler.StartInfo.CreateNoWindow = true;
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;

                compiler.Start();
                this.Enabled = false;
                compiler.WaitForExit();
                this.Enabled = true;
                if (TryFillAirlineFlightsDataGridView(true))
                {
                    filterCheckedListBox.Enabled = true;
                }
                CalculateFlightByStopsCount();
            }
        }
        private void compareButton_Click(object sender, EventArgs e)
        {
            if (TryFillAirlineFlightsDataGridView(false))
            {
                filterCheckedListBox.Enabled = true;
                CalculateFlightByStopsCount();
            }
            CompareChartForm compareChartForm = new CompareChartForm(airlineFlightsDataGridView);
            compareChartForm.Show();
        }
        private void intervalSearchButton_Click(object sender, EventArgs e)
        {
            if (!ErrorNotification())
            {
                IntervalForm intervalForm = new IntervalForm(this);
                intervalForm.Show();
            }
        }
        public void IntervalSearch(DateTimePicker startOfIntervalDateTimePicker, DateTimePicker endOfIntervalDateTimePicker, NumericUpDown differenceNumericUpDown, NumericUpDown patternNumericUpDown)
        {
            string flightType = OWRTcheckBox.Checked ? "R" : "O";
            string connectionCount = directFlightCheckBox.Checked ? "1" : "0";

            int pattern = (int)differenceNumericUpDown.Value;

            int daysToAdd = (int)patternNumericUpDown.Value;

            int daysToSearchCount = int.Parse(endOfIntervalDateTimePicker.Value.Subtract(startOfIntervalDateTimePicker.Value).Days.ToString());

            if (departureAirportTextBox.Text != string.Empty &&
                arrivalAirportTextBox.Text != string.Empty && airlineTextBox.Text != string.Empty)
            {
                Process compiler = new Process();

                compiler.StartInfo.FileName = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Crawlers\\") + $"{airlineTextBox.Text}.exe";

                compiler.StartInfo.CreateNoWindow = true;
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;

                this.Enabled = false;

                for (int i = 0; i < daysToSearchCount - pattern; i = i + pattern)
                {
                    endOfIntervalDateTimePicker.Value = startOfIntervalDateTimePicker.Value;
                    endOfIntervalDateTimePicker.Value = endOfIntervalDateTimePicker.Value.AddDays(daysToAdd);

                    compiler.StartInfo.Arguments = $"\"{departureAirportTextBox.Text.ToUpper()}|{arrivalAirportTextBox.Text.ToUpper()}|" +
                        $"{startOfIntervalDateTimePicker.Value.ToString("yyyy")}|" +
                        $"{startOfIntervalDateTimePicker.Value.ToString("MM")}|" +
                        $"{startOfIntervalDateTimePicker.Value.ToString("dd")}|" +
                        $"{endOfIntervalDateTimePicker.Value.ToString("yyyy")}|" +
                        $"{endOfIntervalDateTimePicker.Value.ToString("MM")}|" +
                        $"{endOfIntervalDateTimePicker.Value.ToString("dd")}|" +
                        $"{Dictionary.TravelClassesDictionary[classComboBox.Text]}|" +
                        $"{flightType}||{connectionCount}\"";

                    compiler.Start();
                    compiler.WaitForExit();

                    startOfIntervalDateTimePicker.Value = startOfIntervalDateTimePicker.Value.AddDays(pattern);
                }

                this.Enabled = true;
                if (TryFillAirlineFlightsDataGridView(true))
                {
                    filterCheckedListBox.Enabled = true;
                }
                CalculateFlightByStopsCount();
            }
        }
        public bool ErrorNotification()
        {
            bool error = false;

            airlineLabel.ForeColor = System.Drawing.Color.Black;
            departureAirportLabel.ForeColor = System.Drawing.Color.Black;
            arrivalAirportLabel.ForeColor = System.Drawing.Color.Black;

            if (airlineTextBox.Text == string.Empty)
            {
                airlineLabel.ForeColor = System.Drawing.Color.Red;
                error = true;
            }
            if (departureAirportTextBox.Text == string.Empty)
            {
                departureAirportLabel.ForeColor = System.Drawing.Color.Red;
                error = true;
            }
            if (arrivalAirportTextBox.Text == string.Empty)
            {
                arrivalAirportLabel.ForeColor = System.Drawing.Color.Red;
                error = true;
            }

            return error;
        }
        public void CalculateFlightByStopsCount()
        {
            int directFlightCount = 0;

            for (int i = 0; i < airlineFlightsDataGridView.Rows.Count - 1; i++)
            {
                if (airlineFlightsDataGridView.Rows[i].Cells[12].Value != null)
                {
                    if (airlineFlightsDataGridView.Rows[i].Cells[3].Value.ToString() == string.Empty &&
                        airlineFlightsDataGridView.Rows[i].Cells[14].Value.ToString() == string.Empty)
                    {
                        directFlightCount++;
                    }
                }
                else
                {
                    if (airlineFlightsDataGridView.Rows[i].Cells[3].Value.ToString() == string.Empty)
                    {
                        directFlightCount++;
                    }
                }
            }

            zeroConnectionLabel.Text = $" ({directFlightCount.ToString()})";
            zeroConnectionLabel.Visible = true;

            oneConnectionLabel.Text = $" ({(airlineFlightsDataGridView.Rows.Count - directFlightCount - 1).ToString()})";
            oneConnectionLabel.Visible = true;
        }
        private void airlineFlightsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cellSelected = airlineFlightsDataGridView.SelectedCells;
            int columnIndex = cellSelected[0].ColumnIndex;
            string cellValue = cellSelected[0].Value.ToString();

            if (columnIndex == 1 || columnIndex == 2 || columnIndex == 3 ||
               columnIndex == 12 || columnIndex == 13 || columnIndex == 14)
            {
                IATAInformationForm iATAInformationForm = new IATAInformationForm(_airportsFromDatabase, cellValue)
                {
                    StartPosition = FormStartPosition.Manual
                };

                var cellRectangle = airlineFlightsDataGridView.GetCellDisplayRectangle(cellSelected[0].ColumnIndex, cellSelected[0].RowIndex, true);

                iATAInformationForm.Left = cellRectangle.Left;
                iATAInformationForm.Top = cellRectangle.Bottom + 170;
                iATAInformationForm.Show();
            }

            if (columnIndex == 4 || columnIndex == 5 || columnIndex == 6 ||
                columnIndex == 15 || columnIndex == 16 || columnIndex == 17 ||
                columnIndex == 23 || columnIndex == 24 || columnIndex == 25)
            {
                CurrencyConverterForm currencyConverterForm = new CurrencyConverterForm(this, airlineFlightsDataGridView.Rows[cellSelected[0].RowIndex].Cells[26].Value.ToString(), _currenciesFromDatabase);
                currencyConverterForm.Show();
            }
        }
        private void filterButton_Click(object sender, EventArgs e)
        {
            TryFillAirlineFlightsDataGridView(false);
        }

        private void chartButton_Click(object sender, EventArgs e)
        {
            CompareChartForm compareChartForm = new CompareChartForm(airlineFlightsDataGridView);
            compareChartForm.Show();
        }
    }
}
