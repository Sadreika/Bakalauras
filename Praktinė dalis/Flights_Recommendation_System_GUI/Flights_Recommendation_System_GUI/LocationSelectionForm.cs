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
        public LocationSelectionForm(MainForm mainform)
        {
            InitializeComponent();
            this.Mainform = mainform;
            mainform.Enabled = false;
        }

        private void LocationSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mainform.Enabled = true;
        }
    }
}
