﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flights_Recommendation_System_GUI
{
    public partial class LocationSelectionForm : Form
    {
        private MainForm Mainform { get; set; }

        private List<string> AirportSuggestionsList = new List<string>();
        private List<string> CitySuggestionsList = new List<string>();
        private List<string> CountrySuggestionsList = new List<string>();
        private List<string> IATASuggestionsList = new List<string>();

        public LocationSelectionForm(MainForm mainform, DataTable dataFromDatabase)
        {
            InitializeComponent();
            this.Mainform = mainform;
            mainform.Enabled = false;

            AirportSuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Airport")).ToList();
            CitySuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("City")).ToList();
            CountrySuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Country")).ToList();
            IATASuggestionsList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("IATA")).ToList();
        }

        private void LocationSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mainform.Enabled = true;
        }

        private void selectionButton_Click(object sender, EventArgs e)
        {

        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            if(locationTextBox.Text.Length >= 3)
            {
                DataTable data = new DataTable();

                data.Columns.Add("Šalis");
                data.Columns.Add("Miestas");
                data.Columns.Add("Oro uostas");
                data.Columns.Add("IATA");

                //List<string> fix
                if(countryRadioButton.Checked)

                for (int i = 0; i < IATASuggestionsList.Count; i++)
                {
                    if (countryRadioButton.Checked && locationTextBox.Text != null)
                    {
                        if (CountrySuggestionsList[i].Contains(locationTextBox.Text))
                        {
                            data.Rows.Add(CountrySuggestionsList[i], CitySuggestionsList[i], AirportSuggestionsList[i], IATASuggestionsList[i]);
                        }
                    }
                    if (cityRadioButton.Checked && locationTextBox.Text != null)
                    {
                        if (CitySuggestionsList[i].Contains(locationTextBox.Text))
                        {
                            data.Rows.Add(CountrySuggestionsList[i], CitySuggestionsList[i], AirportSuggestionsList[i], IATASuggestionsList[i]);
                        }
                    }
                    if (airportRadioButton.Checked && locationTextBox.Text != null)
                    {
                        if (AirportSuggestionsList[i].Contains(locationTextBox.Text))
                        {
                            data.Rows.Add(CountrySuggestionsList[i], CitySuggestionsList[i], AirportSuggestionsList[i], IATASuggestionsList[i]);
                        }
                    }
                }

                locationsDataGridView.DataSource = data;
            }
        }
    }
}
