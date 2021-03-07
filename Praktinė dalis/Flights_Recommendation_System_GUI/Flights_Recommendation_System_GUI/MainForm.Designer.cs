﻿
using System;
using System.Windows.Forms;

namespace Flights_Recommendation_System_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.airlineLabel = new System.Windows.Forms.Label();
            this.departureAirportLabel = new System.Windows.Forms.Label();
            this.arrivalAirportLabel = new System.Windows.Forms.Label();
            this.departureDateLabel = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.arrivalDateLabel = new System.Windows.Forms.Label();
            this.OWRTcheckBox = new System.Windows.Forms.CheckBox();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.departureAirportTextBox = new System.Windows.Forms.TextBox();
            this.arrivalAirportTextBox = new System.Windows.Forms.TextBox();
            this.airlineTextBox = new System.Windows.Forms.TextBox();
            this.departureDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.arrivalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.airlineFlightsDataGridView = new System.Windows.Forms.DataGridView();
            this.collectedDataButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.filterCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.intervalSearchButton = new System.Windows.Forms.Button();
            this.zeroConnectionLabel = new System.Windows.Forms.Label();
            this.lowestPriceLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.biggestPriceLabel = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.travelDurationLabel = new System.Windows.Forms.Label();
            this.travelDutartionTextBox = new System.Windows.Forms.TextBox();
            this.stropsLabel = new System.Windows.Forms.Label();
            this.oneStopCheckBox = new System.Windows.Forms.CheckBox();
            this.zeroStopsCheckBox = new System.Windows.Forms.CheckBox();
            this.oneConnectionLabel = new System.Windows.Forms.Label();
            this.directFlightCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.airlineFlightsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // airlineLabel
            // 
            this.airlineLabel.AutoSize = true;
            this.airlineLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airlineLabel.Location = new System.Drawing.Point(19, 24);
            this.airlineLabel.Name = "airlineLabel";
            this.airlineLabel.Size = new System.Drawing.Size(68, 17);
            this.airlineLabel.TabIndex = 0;
            this.airlineLabel.Text = "Avialinija";
            // 
            // departureAirportLabel
            // 
            this.departureAirportLabel.AutoSize = true;
            this.departureAirportLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAirportLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.departureAirportLabel.Location = new System.Drawing.Point(265, 24);
            this.departureAirportLabel.Name = "departureAirportLabel";
            this.departureAirportLabel.Size = new System.Drawing.Size(136, 17);
            this.departureAirportLabel.TabIndex = 1;
            this.departureAirportLabel.Text = "Išvykimo oro uostas";
            // 
            // arrivalAirportLabel
            // 
            this.arrivalAirportLabel.AutoSize = true;
            this.arrivalAirportLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalAirportLabel.Location = new System.Drawing.Point(265, 61);
            this.arrivalAirportLabel.Name = "arrivalAirportLabel";
            this.arrivalAirportLabel.Size = new System.Drawing.Size(139, 17);
            this.arrivalAirportLabel.TabIndex = 2;
            this.arrivalAirportLabel.Text = "Atvykimo oro uostas";
            // 
            // departureDateLabel
            // 
            this.departureDateLabel.AutoSize = true;
            this.departureDateLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDateLabel.Location = new System.Drawing.Point(570, 24);
            this.departureDateLabel.Name = "departureDateLabel";
            this.departureDateLabel.Size = new System.Drawing.Size(98, 17);
            this.departureDateLabel.TabIndex = 3;
            this.departureDateLabel.Text = "Išvykimo data";
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassLabel.Location = new System.Drawing.Point(931, 24);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(42, 17);
            this.ClassLabel.TabIndex = 4;
            this.ClassLabel.Text = "Klasė";
            // 
            // arrivalDateLabel
            // 
            this.arrivalDateLabel.AutoSize = true;
            this.arrivalDateLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateLabel.Location = new System.Drawing.Point(571, 61);
            this.arrivalDateLabel.Name = "arrivalDateLabel";
            this.arrivalDateLabel.Size = new System.Drawing.Size(101, 17);
            this.arrivalDateLabel.TabIndex = 6;
            this.arrivalDateLabel.Text = "Atvykimo data";
            // 
            // OWRTcheckBox
            // 
            this.OWRTcheckBox.AutoSize = true;
            this.OWRTcheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OWRTcheckBox.Location = new System.Drawing.Point(934, 52);
            this.OWRTcheckBox.Name = "OWRTcheckBox";
            this.OWRTcheckBox.Size = new System.Drawing.Size(130, 21);
            this.OWRTcheckBox.TabIndex = 13;
            this.OWRTcheckBox.Text = "Dvipusė kelionė";
            this.OWRTcheckBox.UseVisualStyleBackColor = true;
            this.OWRTcheckBox.Click += new System.EventHandler(this.OWRTcheckBox_Click);
            // 
            // classComboBox
            // 
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(992, 21);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(125, 24);
            this.classComboBox.TabIndex = 14;
            // 
            // departureAirportTextBox
            // 
            this.departureAirportTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.departureAirportTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.departureAirportTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAirportTextBox.Location = new System.Drawing.Point(413, 21);
            this.departureAirportTextBox.MaxLength = 3;
            this.departureAirportTextBox.Name = "departureAirportTextBox";
            this.departureAirportTextBox.Size = new System.Drawing.Size(125, 22);
            this.departureAirportTextBox.TabIndex = 16;
            this.departureAirportTextBox.DoubleClick += new System.EventHandler(this.departureAirportTextBox_DoubleClick);
            // 
            // arrivalAirportTextBox
            // 
            this.arrivalAirportTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.arrivalAirportTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.arrivalAirportTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalAirportTextBox.Location = new System.Drawing.Point(413, 58);
            this.arrivalAirportTextBox.MaxLength = 3;
            this.arrivalAirportTextBox.Name = "arrivalAirportTextBox";
            this.arrivalAirportTextBox.Size = new System.Drawing.Size(125, 22);
            this.arrivalAirportTextBox.TabIndex = 17;
            this.arrivalAirportTextBox.DoubleClick += new System.EventHandler(this.arrivalAirportTextBox_DoubleClick);
            // 
            // airlineTextBox
            // 
            this.airlineTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.airlineTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.airlineTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airlineTextBox.Location = new System.Drawing.Point(112, 21);
            this.airlineTextBox.Name = "airlineTextBox";
            this.airlineTextBox.Size = new System.Drawing.Size(125, 22);
            this.airlineTextBox.TabIndex = 18;
            // 
            // departureDateTimePicker
            // 
            this.departureDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.departureDateTimePicker.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.departureDateTimePicker.Location = new System.Drawing.Point(686, 23);
            this.departureDateTimePicker.MinDate = new System.DateTime(2021, 2, 10, 0, 0, 0, 0);
            this.departureDateTimePicker.Name = "departureDateTimePicker";
            this.departureDateTimePicker.Size = new System.Drawing.Size(229, 22);
            this.departureDateTimePicker.TabIndex = 19;
            // 
            // arrivalDateTimePicker
            // 
            this.arrivalDateTimePicker.CalendarFont = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.arrivalDateTimePicker.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrivalDateTimePicker.Location = new System.Drawing.Point(687, 61);
            this.arrivalDateTimePicker.MinDate = new System.DateTime(2021, 2, 10, 0, 0, 0, 0);
            this.arrivalDateTimePicker.Name = "arrivalDateTimePicker";
            this.arrivalDateTimePicker.Size = new System.Drawing.Size(228, 22);
            this.arrivalDateTimePicker.TabIndex = 20;
            // 
            // airlineFlightsDataGridView
            // 
            this.airlineFlightsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.airlineFlightsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.airlineFlightsDataGridView.Location = new System.Drawing.Point(12, 146);
            this.airlineFlightsDataGridView.Name = "airlineFlightsDataGridView";
            this.airlineFlightsDataGridView.ReadOnly = true;
            this.airlineFlightsDataGridView.RowHeadersWidth = 51;
            this.airlineFlightsDataGridView.RowTemplate.Height = 24;
            this.airlineFlightsDataGridView.Size = new System.Drawing.Size(1878, 835);
            this.airlineFlightsDataGridView.TabIndex = 21;
            this.airlineFlightsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.airlineFlightsDataGridView_CellContentDoubleClick);
            // 
            // collectedDataButton
            // 
            this.collectedDataButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectedDataButton.Location = new System.Drawing.Point(23, 61);
            this.collectedDataButton.Name = "collectedDataButton";
            this.collectedDataButton.Size = new System.Drawing.Size(214, 29);
            this.collectedDataButton.TabIndex = 22;
            this.collectedDataButton.Text = "Rodyti surinktus duomenis";
            this.collectedDataButton.UseVisualStyleBackColor = true;
            this.collectedDataButton.Click += new System.EventHandler(this.collectedDataButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(1147, 17);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(177, 30);
            this.searchButton.TabIndex = 23;
            this.searchButton.Text = "Atlikti paiešką";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // filterCheckedListBox
            // 
            this.filterCheckedListBox.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterCheckedListBox.FormattingEnabled = true;
            this.filterCheckedListBox.Location = new System.Drawing.Point(1656, 17);
            this.filterCheckedListBox.Name = "filterCheckedListBox";
            this.filterCheckedListBox.Size = new System.Drawing.Size(234, 104);
            this.filterCheckedListBox.TabIndex = 24;
            this.filterCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.filterCheckedListBox_SelectedIndexChanged);
            // 
            // compareButton
            // 
            this.compareButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareButton.Location = new System.Drawing.Point(1147, 90);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(177, 29);
            this.compareButton.TabIndex = 25;
            this.compareButton.Text = "Atlikti palyginimą";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // intervalSearchButton
            // 
            this.intervalSearchButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalSearchButton.Location = new System.Drawing.Point(1147, 55);
            this.intervalSearchButton.Name = "intervalSearchButton";
            this.intervalSearchButton.Size = new System.Drawing.Size(177, 29);
            this.intervalSearchButton.TabIndex = 26;
            this.intervalSearchButton.Text = "Paieška intervale";
            this.intervalSearchButton.UseVisualStyleBackColor = true;
            this.intervalSearchButton.Click += new System.EventHandler(this.intervalSearchButton_Click);
            // 
            // zeroConnectionLabel
            // 
            this.zeroConnectionLabel.AutoSize = true;
            this.zeroConnectionLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroConnectionLabel.Location = new System.Drawing.Point(685, 96);
            this.zeroConnectionLabel.Name = "zeroConnectionLabel";
            this.zeroConnectionLabel.Size = new System.Drawing.Size(30, 17);
            this.zeroConnectionLabel.TabIndex = 27;
            this.zeroConnectionLabel.Text = " (0)";
            // 
            // lowestPriceLabel
            // 
            this.lowestPriceLabel.AutoSize = true;
            this.lowestPriceLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowestPriceLabel.Location = new System.Drawing.Point(1340, 23);
            this.lowestPriceLabel.Name = "lowestPriceLabel";
            this.lowestPriceLabel.Size = new System.Drawing.Size(107, 17);
            this.lowestPriceLabel.TabIndex = 28;
            this.lowestPriceLabel.Text = "Mažiausia kaina";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(1504, 20);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 29;
            // 
            // biggestPriceLabel
            // 
            this.biggestPriceLabel.AutoSize = true;
            this.biggestPriceLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.biggestPriceLabel.Location = new System.Drawing.Point(1340, 55);
            this.biggestPriceLabel.Name = "biggestPriceLabel";
            this.biggestPriceLabel.Size = new System.Drawing.Size(109, 17);
            this.biggestPriceLabel.TabIndex = 30;
            this.biggestPriceLabel.Text = "Didžiausia kaina";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(1504, 51);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown2.TabIndex = 31;
            // 
            // travelDurationLabel
            // 
            this.travelDurationLabel.AutoSize = true;
            this.travelDurationLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.travelDurationLabel.Location = new System.Drawing.Point(1340, 90);
            this.travelDurationLabel.Name = "travelDurationLabel";
            this.travelDurationLabel.Size = new System.Drawing.Size(151, 17);
            this.travelDurationLabel.TabIndex = 32;
            this.travelDurationLabel.Text = "Kelionės trukmė (max)";
            // 
            // travelDutartionTextBox
            // 
            this.travelDutartionTextBox.Enabled = false;
            this.travelDutartionTextBox.Location = new System.Drawing.Point(1524, 85);
            this.travelDutartionTextBox.Name = "travelDutartionTextBox";
            this.travelDutartionTextBox.Size = new System.Drawing.Size(100, 22);
            this.travelDutartionTextBox.TabIndex = 33;
            // 
            // stropsLabel
            // 
            this.stropsLabel.AutoSize = true;
            this.stropsLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stropsLabel.Location = new System.Drawing.Point(571, 96);
            this.stropsLabel.Name = "stropsLabel";
            this.stropsLabel.Size = new System.Drawing.Size(74, 17);
            this.stropsLabel.TabIndex = 34;
            this.stropsLabel.Text = "Sustojimai";
            // 
            // oneStopCheckBox
            // 
            this.oneStopCheckBox.AutoSize = true;
            this.oneStopCheckBox.Enabled = false;
            this.oneStopCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneStopCheckBox.Location = new System.Drawing.Point(754, 96);
            this.oneStopCheckBox.Name = "oneStopCheckBox";
            this.oneStopCheckBox.Size = new System.Drawing.Size(37, 21);
            this.oneStopCheckBox.TabIndex = 36;
            this.oneStopCheckBox.Text = "1";
            this.oneStopCheckBox.UseVisualStyleBackColor = true;
            // 
            // zeroStopsCheckBox
            // 
            this.zeroStopsCheckBox.AutoSize = true;
            this.zeroStopsCheckBox.Enabled = false;
            this.zeroStopsCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroStopsCheckBox.Location = new System.Drawing.Point(651, 95);
            this.zeroStopsCheckBox.Name = "zeroStopsCheckBox";
            this.zeroStopsCheckBox.Size = new System.Drawing.Size(39, 21);
            this.zeroStopsCheckBox.TabIndex = 37;
            this.zeroStopsCheckBox.Text = "0";
            this.zeroStopsCheckBox.UseVisualStyleBackColor = true;
            // 
            // oneConnectionLabel
            // 
            this.oneConnectionLabel.AutoSize = true;
            this.oneConnectionLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneConnectionLabel.Location = new System.Drawing.Point(797, 97);
            this.oneConnectionLabel.Name = "oneConnectionLabel";
            this.oneConnectionLabel.Size = new System.Drawing.Size(30, 17);
            this.oneConnectionLabel.TabIndex = 39;
            this.oneConnectionLabel.Text = " (0)";
            // 
            // directFlightCheckBox
            // 
            this.directFlightCheckBox.AutoSize = true;
            this.directFlightCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directFlightCheckBox.Location = new System.Drawing.Point(934, 80);
            this.directFlightCheckBox.Name = "directFlightCheckBox";
            this.directFlightCheckBox.Size = new System.Drawing.Size(147, 21);
            this.directFlightCheckBox.TabIndex = 40;
            this.directFlightCheckBox.Text = "Tiesioginis skrydis";
            this.directFlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1902, 993);
            this.Controls.Add(this.directFlightCheckBox);
            this.Controls.Add(this.oneConnectionLabel);
            this.Controls.Add(this.zeroStopsCheckBox);
            this.Controls.Add(this.oneStopCheckBox);
            this.Controls.Add(this.stropsLabel);
            this.Controls.Add(this.travelDutartionTextBox);
            this.Controls.Add(this.travelDurationLabel);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.biggestPriceLabel);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lowestPriceLabel);
            this.Controls.Add(this.zeroConnectionLabel);
            this.Controls.Add(this.intervalSearchButton);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.filterCheckedListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.collectedDataButton);
            this.Controls.Add(this.airlineFlightsDataGridView);
            this.Controls.Add(this.arrivalDateTimePicker);
            this.Controls.Add(this.departureDateTimePicker);
            this.Controls.Add(this.airlineTextBox);
            this.Controls.Add(this.arrivalAirportTextBox);
            this.Controls.Add(this.departureAirportTextBox);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.OWRTcheckBox);
            this.Controls.Add(this.arrivalDateLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.departureDateLabel);
            this.Controls.Add(this.arrivalAirportLabel);
            this.Controls.Add(this.departureAirportLabel);
            this.Controls.Add(this.airlineLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Skrydžių rekomendavimo sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.airlineFlightsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label airlineLabel;
        private System.Windows.Forms.Label departureAirportLabel;
        private System.Windows.Forms.Label arrivalAirportLabel;
        private System.Windows.Forms.Label departureDateLabel;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label arrivalDateLabel;
        private System.Windows.Forms.CheckBox OWRTcheckBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.TextBox departureAirportTextBox;
        private System.Windows.Forms.TextBox arrivalAirportTextBox;
        private System.Windows.Forms.TextBox airlineTextBox;
        private System.Windows.Forms.DateTimePicker departureDateTimePicker;
        private System.Windows.Forms.DateTimePicker arrivalDateTimePicker;
        private System.Windows.Forms.DataGridView airlineFlightsDataGridView;
        private System.Windows.Forms.Button collectedDataButton;
        private System.Windows.Forms.Button searchButton;
        private CheckedListBox filterCheckedListBox;
        private Button compareButton;
        private Button intervalSearchButton;
        private Label zeroConnectionLabel;
        private Label lowestPriceLabel;
        private NumericUpDown numericUpDown1;
        private Label biggestPriceLabel;
        private NumericUpDown numericUpDown2;
        private Label travelDurationLabel;
        private TextBox travelDutartionTextBox;
        private Label stropsLabel;
        private CheckBox oneStopCheckBox;
        private CheckBox zeroStopsCheckBox;
        private Label oneConnectionLabel;
        private CheckBox directFlightCheckBox;
    }
}

